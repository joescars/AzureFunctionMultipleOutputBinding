using System;

public static void Run(string input, TraceWriter log, out string outputQueueItem, ICollector<FaceResult> outputTable)
{
    log.Info($"C# manually triggered function called with input: {input}");

    // DO SOMETHING
    // Your custom function code goes here
    // i.e. cognitive services face detection

    // Create message   
    string msg = $"Notification! 25 Faces Detected";
    log.Info(msg);

    // Store message in Azure Table Storage    
    outputTable.Add(
        new FaceResult() { 
            PartitionKey = "FaceTracking", 
            RowKey = Guid.NewGuid().ToString(), 
            Message = msg }
        );
    // Store message in Azure Storage Queue    
    outputQueueItem = msg; 

}

// Example class to storage messages regarding face detection
public class FaceResult
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Message { get; set; }
}