namespace PNRAnalysisSystem.Models
{
    public class PNRModel
    {
        public class SFlightPassenger
        {
            public string flightNo { get; set; }
            public string scheduleFlightTime { get; set; }
            public string actualFlightTime { get; set; }
            public string travelDocNumber { get; set; }
            public string passengerSeqNo { get; set; }
            public string name { get; set; }
            public string dateOfBirth { get; set; }
            public string nationality { get; set; }
            public string gender { get; set; }
            public string seatNo { get; set; }
        }

        public class SameFlightTask
        {
            public string taskId { get; set; }
            public string agentId { get; set; }
            public string agentName { get; set; }
            public string batchStartedTime { get; set; }
            public string batchEndedTime { get; set; }
            public string status { get; set; }
            public string comparisonStatus { get; set; }
            public string startedDate { get; set; }
            public string endedDate { get; set; }
            public List<SameFlightTask_Passengers> Passengers { get; set; }
        }
        public class SameFlightTask_Passengers
        {
            public string dateOfBirth { get; set; }
            public string ename { get; set; }
        }
    }
}
