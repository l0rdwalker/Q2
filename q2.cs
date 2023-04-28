using System;

public class q2 {
    private int[][] data;

    private int x = int.MaxValue; 
    private int y = int.MinValue;
    private int[] tuple;

    private myHeap minHeap; 
    private myHeap maxHeap;

    public q2(int[][] data) {
        this.minHeap = new myHeap(true);
        this.maxHeap = new myHeap(false);
        tuple = new int[2];
        this.data = data;

        init();
    }

    public void init() {
        for (int x = 0; x < this.data.Length; x++) {
            if (this.data[x][0] < this.x) {
                this.x = this.data[x][0];
            }
            if (this.data[x][this.data[x].Length-1] > this.y) {
                this.y = this.data[x][this.data[x].Length-1];
            }

            this.minHeap.addNode(this.data[x]);
            this.maxHeap.addNode(this.data[x]);
        }
    }

    public void left_forward() {
        int temp = minHeap.shift();
        if (temp < this.y) {
            this.x = temp;
        }
    }

    public void right_backward() {
        int temp = maxHeap.shift();
        if (temp > this.x) {
            this.y = temp;
        }
    }

    public int[] getPair() {
        this.tuple[0] = this.x;
        this.tuple[1] = this.y;
        
        return this.tuple;
    }

    public int[][] getArray(){
        return this.data;
    }
}