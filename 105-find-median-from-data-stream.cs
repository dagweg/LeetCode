public class MedianFinder {

    public PriorityQueue<int,int> LeftQueue;
    public PriorityQueue<int,int> RightQueue;

    public MedianFinder() {
        LeftQueue = new(Comparer<int>.Create((x,y) => y-x)); // max-heap
        RightQueue = new(); // min-heap
    }
    
    public void AddNum(int num) { 
        LeftQueue.Enqueue(num,num); 

        if(LeftQueue.Count - RightQueue.Count == 2){
            int left = LeftQueue.Dequeue();
            RightQueue.Enqueue(left,left);
        }

        if(RightQueue.Count > 0 && LeftQueue.Peek() > RightQueue.Peek()){
            int right = RightQueue.Dequeue();
            int left = LeftQueue.DequeueEnqueue(right,right);
            RightQueue.Enqueue(left,left);
        }
    }
    
    public double FindMedian() { 
        int count = LeftQueue.Count + RightQueue.Count;
        if(count % 2 == 0)
            return (LeftQueue.Peek() + RightQueue.Peek())/2.0;
        else
            return LeftQueue.Peek();
        
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
