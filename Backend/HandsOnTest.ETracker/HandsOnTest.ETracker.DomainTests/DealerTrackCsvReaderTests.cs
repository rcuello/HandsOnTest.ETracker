using HandsOnTest.ETracker.CsvParser;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HandsOnTest.ETracker.DomainTests
{
    public class DealerTrackCsvReaderTests
    {
        #region Scenarios
        private string Get_Csv_With_13_Elements()
        {
            var csv = new StringBuilder();
            csv.Append("DealNumber,CustomerName,DealershipName,Vehicle,Price,Date\n");
            csv.Append("5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,\"429, 987\",6/19/2018\n");
            csv.Append("5132,Rahima Skinner,Seven Star Dealership,2009 Lamborghini Gallardo Carbon Fiber LP-560,\"169, 900\", 1/14/2018\n");
            csv.Append("5795,Aroush Knapp,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,\"289, 900\", 6/7/2018\n");
            csv.Append("5212,Richard Spencer,Milton Jeep Limited,2018 Jeep Grand Cherokee Trackhawk,\"134, 599\", 7/13/2018\n");
            csv.Append("5268,Naseem Snow,\"Scott Toronto Dealership, Inc\", 2018 BMW M760Li Xdrive Sedan,\"177, 608\", 1/21/2018\n");
            csv.Append("5765,Storm William,Mythicgarcia Dealership LTDA,2018 Mercedes-Benz S-Class Cabriolet,\"189, 693\", 3/22/2018\n");
            csv.Append("5465,Ségolène Lémery,Richaremus Jafur Dealer,2017 Chevrolet Corvette Z06,\"132, 925\", 3/4/2018\n");
            csv.Append("5545,Élie Boutroux,Horseallen Cars,2018 Lexus LS 500h ,\"164, 810\", 2/5/2018\n");
            csv.Append("5890,Ronnie Griffiths,Cheruharrison Auto,2018 Nissan GT-R Premium,\"147, 018\", 4/8/2018\n");
            csv.Append("5812,Anwar Hoffman,\"Legowart Kingorty, Ltd.\", 2018 Jeep Grand Cherokee Trackhawk,\"130, 936\", 5/11/2018\n");
            csv.Append("5298,Jakob Osborn,Coreen Dealership,2017 Dodge Viper New Car ACR,\"229, 998\", 6/11/2018\n");
            csv.Append("5359,Maxine Daniels,Saskatoon Ferrari,2017 Ferrari 488 Spider,\"419, 955\", 7/15/2018\n");
            csv.Append("5712,Donald Waters,Milton Jeep Limited,2018 Jeep Grand Cherokee Trackhawk,\"135, 500\", 6/21/2018\n");
            return csv.ToString();
        }

        private string Get_Csv_WhiteSpaces_And_BreakLines_At_The_Beggining_With_13_Elements_()
        {
            var csv = new StringBuilder();
            csv.Append(string.Empty);
            csv.Append("\n");
            csv.Append("DealNumber,CustomerName,DealershipName,Vehicle,Price,Date\n");
            csv.Append("5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,\"429, 987\",6/19/2018\n");
            csv.Append("5132,Rahima Skinner,Seven Star Dealership,2009 Lamborghini Gallardo Carbon Fiber LP-560,\"169, 900\", 1/14/2018\n");
            csv.Append("5795,Aroush Knapp,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,\"289, 900\", 6/7/2018\n");
            csv.Append("5212,Richard Spencer,Milton Jeep Limited,2018 Jeep Grand Cherokee Trackhawk,\"134, 599\", 7/13/2018\n");
            csv.Append("5268,Naseem Snow,\"Scott Toronto Dealership, Inc\", 2018 BMW M760Li Xdrive Sedan,\"177, 608\", 1/21/2018\n");
            csv.Append("5765,Storm William,Mythicgarcia Dealership LTDA,2018 Mercedes-Benz S-Class Cabriolet,\"189, 693\", 3/22/2018\n");
            csv.Append("5465,Ségolène Lémery,Richaremus Jafur Dealer,2017 Chevrolet Corvette Z06,\"132, 925\", 3/4/2018\n");
            csv.Append("5545,Élie Boutroux,Horseallen Cars,2018 Lexus LS 500h ,\"164, 810\", 2/5/2018\n");
            csv.Append("5890,Ronnie Griffiths,Cheruharrison Auto,2018 Nissan GT-R Premium,\"147, 018\", 4/8/2018\n");
            csv.Append("5812,Anwar Hoffman,\"Legowart Kingorty, Ltd.\", 2018 Jeep Grand Cherokee Trackhawk,\"130, 936\", 5/11/2018\n");
            csv.Append("5298,Jakob Osborn,Coreen Dealership,2017 Dodge Viper New Car ACR,\"229, 998\", 6/11/2018\n");
            csv.Append("5359,Maxine Daniels,Saskatoon Ferrari,2017 Ferrari 488 Spider,\"419, 955\", 7/15/2018\n");
            csv.Append("5712,Donald Waters,Milton Jeep Limited,2018 Jeep Grand Cherokee Trackhawk,\"135, 500\", 6/21/2018\n");
            return csv.ToString();
        }

        private string GetCsv_With_Break_Lines()
        {
            var csv = new StringBuilder();
            csv.Append("\n");
            csv.Append("\n");
            csv.Append("\n");
            return csv.ToString();
        }

        private string GetCsv_With_TwoElements_WithMissionVehicleAndCustomerName_Column()
        {
            var csv = new StringBuilder();
            csv.Append("DealNumber,CustomerName,DealershipName,Vehicle,Price,Date\n");
            csv.Append("5469,Milli Fulton,Sun of Saskatoon,,\"429, 987\",6/19/2018\n");
            csv.Append("5712,,Milton Jeep Limited,2018 Jeep Grand Cherokee Trackhawk,\"135, 500\", 6/21/2018\n");
            return csv.ToString();
        }
        private string GetCsv_With_NullContent()
        {
            return null;
        }

        #endregion

        [Fact]
        public async Task ParseContent_WhenReceiveANullContent_Then_Return0Elements()
        {
            //Arrange
            var csv = GetCsv_With_NullContent();

            //Act
            var reader      = new DealerTrackCsvReader();
            var collection  = await reader.ParseContent(csv);
            var collectionSize = collection.Count();

            //Asert
            var expectedSize = 0;
            Assert.Equal(expectedSize, collectionSize);

        }


        [Fact]
        public async Task ParseContent_WhenReceiveAStringContentWithElements_Then_IgnoreColumnHeader()
        {
            //Arrange
            var csv = Get_Csv_With_13_Elements(); 

            //Act
            var reader = new DealerTrackCsvReader();
            var collection = await reader.ParseContent(csv);
            var firstData = collection.FirstOrDefault();

            //Asert
            var expectedFirstDealNumber = "5469";
            Assert.Equal(expectedFirstDealNumber, firstData?.DealNumber);

        }

        [Fact]
        public async Task ParseContent_WhenReceiveAStringContentWith13Elements_Then_ReturnCount13Elements()
        {
            //Arrange
            var csv = Get_Csv_With_13_Elements();

            //Act
            var reader      = new DealerTrackCsvReader();
            var collection  = await reader.ParseContent(csv);
            var collectionCount = collection.Count();

            //Asert
            var expectedCollectionSize = 13;
            Assert.Equal(expectedCollectionSize,collectionCount);
        }


        [Fact]
        public async Task ParseContent_WhenReceiveAStringWithBreakLines_Then_ReturnCount0Element()
        {
            //Arrange
            var csv = GetCsv_With_Break_Lines();

            //Act
            var reader      = new DealerTrackCsvReader();
            var collection  = await reader.ParseContent(csv);


            //Asert
            var expectedCollectionSize = 0;
            Assert.Equal(expectedCollectionSize, collection.Count());

        }

        [Fact]
        public async Task ParseContent_WhenReceiveAStringContentWithBreakLineAndWhiteSpaceAtTheBeggining_Then_ReturnCount13Elements()
        {
            //Arrange
            var csv = Get_Csv_WhiteSpaces_And_BreakLines_At_The_Beggining_With_13_Elements_();

            //Act
            var reader = new DealerTrackCsvReader();
            var collection = await reader.ParseContent(csv);
            var collectionCount = collection.Count();

            //Asert
            var expectedCollectionSize = 13;
            Assert.Equal(expectedCollectionSize, collectionCount);
        }

        [Fact]
        public async Task ParseContent_WhenReceiveAStringWithMissingColumns_Then_Return2Elements_With_NullColumnValue()
        {
            //Arrange
            var csv = GetCsv_With_TwoElements_WithMissionVehicleAndCustomerName_Column();

            //Act
            var reader = new DealerTrackCsvReader();
            var collection = await reader.ParseContent(csv);
            var collectionCount = collection.Count();
            var firstElement = collection.First();
            var lastElement = collection.Last();

            //Asert
            var expectedCollectionSize =2 ;
            Assert.Equal(expectedCollectionSize, collectionCount);

            Assert.Empty(firstElement.Vehicle);

            Assert.Empty(lastElement.CustomerName);
        }
    }
}