using System;

public class myHeap {
    private node root; 
    private node fstNode; //Keep track of first node on current level
    private node prevLstNode; //Allows for backtracking, controlling the heap depth size
    private node currNode; //Keep track of current node add children too
    private int currIndex; //Keep track of the most recently added
    private int currLevel; //Keep track of the total number of levels
    private int levelQTY; //Keep track of how many nodes should be in each level
    private node latestNode; //The nost which has been added most previously
    private int size; //The total size of the heap
    private bool isMin; //Controls if the heap is a min or max heap
    public myHeap(bool isMin = true) {
        this.root = null;
        this.isMin = isMin;
    }

    public int shift() {
        int returnVal = this.root.getVal()[this.root.getLstIndex()];

        if (isMin) {
            if (this.root.getVal().Length > this.root.getLstIndex()+1) {
                root.increment();
                root.downHeap();
            } else {
                pop();
            }
        } else {
            if ( this.root.getLstIndex() != 0) {
                root.decrement();
                root.downHeap();
            } else {
                pop();
            }
        }

        return returnVal;
    }

    public int[] pop() {
        int[] temp = new int[0];
        if (this.size > 0) {

            this.size--;
            this.currIndex--;
            if (this.currIndex == 0) {
                this.levelQTY = levelQTY / 2;
                this.currIndex = this.levelQTY;
            }

            temp = this.root.getVal();
            this.root.setVal(latestNode.getVal());
            this.root.setLstIndex(latestNode.getLstIndex());

            latestNode.isolate();
            latestNode = latestNode.SiblingLeft();

            this.root.downHeap();
            return temp;
        }
        return temp;
    }

    public void addNode(int[] val){
        this.size++;
        node newNode = new node(val,this.isMin);
        if (this.root == null) {
            this.root = newNode;
            this.currNode = newNode;
            this.fstNode = this.root;
            this.currLevel = 1; 
            this.levelQTY = 2;
            this.currIndex = 0; 
            this.prevLstNode = newNode;
        } else {
            configLevel();

            this.currNode.addChild(newNode);
            newNode.setParent(this.currNode);

            if (this.latestNode != null) {
                this.latestNode.setSiblingRight(newNode);
                newNode.setSiblingLeft(this.latestNode);
            } else if (this.latestNode == null) {
                newNode.setSiblingLeft(this.prevLstNode);
                this.prevLstNode.setSiblingRight(newNode);
            } else {
                newNode.setSiblingLeft(this.latestNode);
            }
            
            this.latestNode = newNode;
            newNode.upHeap();
        }
    }

    public void configLevel() {
        this.currIndex++;

        if (this.currIndex > this.levelQTY) {
            this.levelQTY = this.levelQTY * 2;
            this.currIndex = 1;
            this.currLevel++;

            this.prevLstNode = this.currNode.ChildRight();
            this.currNode = this.fstNode.ChildLeft();
            this.fstNode = this.currNode;
            this.latestNode = null;
        }

        if (this.currNode.isFull()) {
            this.currNode = this.currNode.SiblingRight();
        }
    }
}