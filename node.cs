using System;

public class node {
    private node childLeft;
    private node childRight; 
    private node siblingLeft; 
    private node siblingRight; 
    private node parent; 
    private int[] val;
    private int valIndex;
    private bool isMax;
    public node(int[] val,bool isMax) {
        this.val = val;
        this.isMax = isMax;

        if (this.isMax) {
            this.valIndex = 0;
        } else {
            this.valIndex = this.val.Length-1;
        }
    }
    public bool compare(int num1, int num2) {
        if (this.isMax) {   
            return (num1 < num2);
        } else {
            return (num1 > num2);
        }
    }
    public int getLstIndex() {
        return valIndex;
    }
    public void increment() {
        if (valIndex+1 != val.Length) {
            valIndex++;
        }
    }
    public void decrement() {
        if (valIndex != 0) {
            valIndex--;
        }
    }

    public void setLstIndex(int index) {
        this.valIndex = index;
    }

    public void upHeap() {
        if (this.parent != null) {
            if (compare(this.val[this.valIndex],this.parent.getVal()[this.parent.getLstIndex()])){
                int[] tempLst = this.val;
                int tempIndex = this.valIndex;

                this.val = this.parent.getVal();
                this.valIndex = this.parent.getLstIndex();

                this.parent.setVal(tempLst);
                this.parent.setLstIndex(tempIndex);

                this.parent.upHeap();
            }
        }
    }

    public void downHeap() {
        if (isLeaf() == false) {
            node tempNode = equalityCheck();

            if (compare(tempNode.getVal()[tempNode.getLstIndex()],this.val[this.valIndex])) {
                int[] temp = this.val;
                int tempIndex = this.valIndex;

                this.val = tempNode.getVal();
                this.valIndex = tempNode.getLstIndex();

                tempNode.setVal(temp);
                tempNode.setLstIndex(tempIndex);

                tempNode.downHeap();
            }
        }
    }

    private node equalityCheck() {
        if (childRight != null) {
            if (compare(childLeft.getVal()[childLeft.getLstIndex()],
            childRight.getVal()[childRight.getLstIndex()])) {
                return childLeft;
            }
            return childRight;
        }
        return childLeft;
    }

    public bool isLeaf() {
        return childLeft == null & childRight == null;
    }

    public void isolate(node remove = null) {
        if (remove == null){
            if (this.parent != null) {
                this.siblingLeft.setSiblingRight(null);
                this.parent.isolate(this);
            }
        } else {
            if (childRight == remove) {
                childRight = null;
            } else {
                childLeft = null;
            }
        }
    }

    public void setVal(int[] val) {
        this.val = val;
    }

    public int[] getVal() {
        return this.val;
    }

    public node getParent() {
        return this.parent;
    }

    public void setParent(node newNode) {
        this.parent = newNode;
    }

    public void addChild(node newNode) {
        if (this.childLeft == null) {
            this.childLeft = newNode;
        } else if (this.childRight == null) {
            this.childRight = newNode;
        }
    }

    public bool isFull() {
        return (this.childRight != null);
    }

    public node SiblingLeft() {
        return this.siblingLeft;
    }

    public node SiblingRight() {
        return this.siblingRight;
    }

    public node ChildLeft() {
        return this.childLeft;
    }

    public node ChildRight() {
        return this.childRight;
    }

    public void setSiblingLeft(node newNode) {
        this.siblingLeft = newNode;
    }

    public void setSiblingRight(node newNode){
        this.siblingRight = newNode;
    }

    public void setChildLeft(node newNode) {
        this.childLeft = newNode;
    }

    public void setChildRight(node newNode) {
        this.childRight = newNode; 
    }
}