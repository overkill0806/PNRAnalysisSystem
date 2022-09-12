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
        public class SFlightPassenger_View
        {
            public string seatNo { get; set; }
            public string name { get; set; }
            public string prnMainSeqNo { get; set; }
            public string bookRefId { get; set; }
            public string passengerSeqNo { get; set; }
        }

        public class SameFlightTask
        {
            public string taskId { get; set; }
            public string agentId { get; set; }
            public string agentName { get; set; }
            public string batchStartedTime { get; set; }
            public string batchEndedTime { get; set; }

            public string tstatus;
            public string status
            {
                get { return tstatus; }
                set { tstatus = TransStatus[value]; }
            }
            public string tcomparisonStatus;
            public string comparisonStatus
            {
                get { return tcomparisonStatus; }
                set { tcomparisonStatus = TransComparisonStatus[value]; }
            }
            public string startedDate { get; set; }
            public string endedDate { get; set; }
            public List<SameFlightTask_Passengers> Passengers { get; set; }
        }
        public class SameFlightTask_Passengers
        {
            public string dateOfBirth { get; set; }
            public string ename { get; set; }
        }
        public class SameFlightTask_View
        {
            public string travelDocNbr { get; set; }
            public string flightNo { get; set; }
            public string scheduleFlightTime { get; set; }
            public string actualFlightTime { get; set; }
            public string name { get; set; }
            public string dateOfBirth { get; set; }
            public string nationality { get; set; }
            public string gender { get; set; }
            public string pnrMainSeqNo { get; set; }
            public string bookRefId { get; set; }
            public string passengerSeqNo { get; set; }
        }


        public class MultinationalModel
        {
            public string travelDocNbr { get; set; }
            public string flightDate { get; set; }
            public string flightNo { get; set; }
            public string passengerSeqNo { get; set; }
            public string issuingLoc { get; set; }
            public string nationality { get; set; }
            public string dateOfBirth { get; set; }
            public string name { get; set; }
            public string expiryDate { get; set; }
        }
        public class LuggageModel
        {
            public string taskId { get; set; }
            public string agentId { get; set; }
            public string agentName { get; set; }
            public string batchStartedTime { get; set; }
            public string batchEndedTime { get; set; }

            public string tstatus;
            public string status
            {
                get { return tstatus; }
                set { tstatus = TransStatus[value]; }
            }
            public string tcomparisonStatus;
            public string comparisonStatus
            {
                get { return tcomparisonStatus; }
                set { tcomparisonStatus = TransComparisonStatus[value]; }
            }
            public string startedDate { get; set; }
            public string endedDate { get; set; }
            public string tluggageWeight;
            public string luggageWeight 
            {
                get { return tluggageWeight; }
                set { tluggageWeight = TransWeight[value]; }
            }
        }
        public class LuggageViewModel
        {
            public string travelDocNbr { get; set; }
            public string flightNo { get; set; }
            public string scheduleFlightTime { get; set; }
            public string actualFlightTime { get; set; }
            public string departureAirportLocCode { get; set; }
            public string arrivalAirportLocCode { get; set; }
            public string name { get; set; }
            public string dateOfBirth { get; set; }
            public string nationality { get; set; }
            public string gender { get; set; }
            public string prnMainSeqNo { get; set; }
            public string bookRefId { get; set; }
            public string passengerSeqNo { get; set; }
            public string luggageQuantity { get; set; }
            public string luggageWeight { get; set; }
        }
        public class HighFreqQueryModel
        {
            public string taskId { get; set; }
            public string agentId { get; set; }
            public string agentName { get; set; }
            public string batchStartedTime { get; set; }
            public string batchEndedTime { get; set; }

            public string tstatus;
            public string status
            {
                get { return tstatus; }
                set { tstatus = TransStatus[value]; }
            }
            public string tcomparisonStatus;
            public string comparisonStatus
            {
                get { return tcomparisonStatus; }
                set { tcomparisonStatus = TransComparisonStatus[value]; }
            }
            public string startedDate { get; set; }
            public string endedDate { get; set; }
            public string nation { get; set; }
            public string numberOfEntries { get; set; }
        }
        public class HighFreqQueryViewModel
        {
            public string startedDate { get; set; }
            public string endedDate { get; set; }
            public string numberOfEntries { get; set; }
            public string name { get; set; }
            public string dateOfBirth { get; set; }
            public string nationality { get; set; }
            public string gender { get; set; }
        }

        #region Translate
        public static Dictionary<string, string> TransStatus = new Dictionary<string, string>()
        {
            { "PROCESSING","作業中"},
            { "FINISHED","完成"},
            { "NO_DATA","無資料"}
        };
        public static Dictionary<string, string> TransComparisonStatus = new Dictionary<string, string>()
        {
            { "MATCHED","比中"},
            { "MISMATCHED","未比中"},
            { "IN_PROGRESS","作業中"}
        };
        public static Dictionary<string, string> TransWeight = new Dictionary<string, string>
        {
            {"ONE_TO_TEN","1-10kg" },
            {"TEN_TO_TWENTY","11-20kg" },
            {"TWENTY_TO_THIRTY","21-30kg" },
            {"OVER_THIRTY","30kg以上" },
        };
        #endregion
    }
}
