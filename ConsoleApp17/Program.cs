using System;
using System.Threading;
using Amazon.Rekognition.Model;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("AKIAU65SRJDXLD3MUKEF", "/jT4FxGDl4kWaBf06y3HD1AsiRHu6MEwmpleawRS");

            var rekognition = new Amazon.Rekognition.AmazonRekognitionClient(awsCreden‌tials, Amazon.RegionEndpoint.EUWest2);
            var res = rekognition.StartFaceDetectionAsync(new Amazon.Rekognition.Model.StartFaceDetectionRequest() 
            { Video = new Amazon.Rekognition.Model.Video() { S3Object = new Amazon.Rekognition.Model.S3Object() 
            { Bucket = "videos322", Name = "v1.mp4" } } }).Result;

       
            GetFaceDetectionResponse result;
            do
            {
                result = rekognition.GetFaceDetectionAsync(new Amazon.Rekognition.Model.GetFaceDetectionRequest() { JobId = res.JobId }).Result;
                if (result.JobStatus == Amazon.Rekognition.VideoJobStatus.SUCCEEDED)
                {
                    break;
                }
            } while (true);

          
            result.Faces.ForEach(x => Console.WriteLine(x.Face.Confidence));
        }
    }
}
