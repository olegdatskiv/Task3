using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Globalization.CultureInfo;
using Task3_2_;
using System.Collections.Generic;


namespace Task3_2_UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private TestContext testContext;
        public TestContext TestContext { get => testContext; set => testContext = value; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\testData1.csv",
                    "testData1#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem("testData1.csv")]

        public void EqualsTestMethodEquals()
        {
            //Arrange
            string data1 = TestContext.DataRow["line1"].ToString();
            string data2 = TestContext.DataRow["line2"].ToString();
            string[] coefficients1 = data1.Split(' ');
            string[] coefficients2 = data2.Split(' ');
            Line firstLine = new Line(double.Parse(coefficients1[0], InvariantCulture), double.Parse(coefficients1[1], InvariantCulture),
                                        double.Parse(coefficients1[2], InvariantCulture));
            Line secondLine = new Line(double.Parse(coefficients2[0], InvariantCulture), double.Parse(coefficients2[1], InvariantCulture),
                                        double.Parse(coefficients2[2], InvariantCulture));
            bool expectedResult = bool.Parse(TestContext.DataRow["result"].ToString());

            //Act
            bool result = firstLine.Equals(secondLine);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\testData2.csv",
                    "testData2#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem("testData2.csv")]

        public void AreIntersectedTestMetodEquals()
        {
            //Arrange
            string data1 = TestContext.DataRow["line1"].ToString();
            string data2 = TestContext.DataRow["line2"].ToString();
            string[] coefficients1 = data1.Split(' ');
            string[] coefficients2 = data2.Split(' ');
            Line firstLine = new Line(double.Parse(coefficients1[0], InvariantCulture), double.Parse(coefficients1[1], InvariantCulture),
                                        double.Parse(coefficients1[2], InvariantCulture));
            Line secondLine = new Line(double.Parse(coefficients2[0], InvariantCulture), double.Parse(coefficients2[1], InvariantCulture),
                                        double.Parse(coefficients2[2], InvariantCulture));
            bool expectedResult = bool.Parse(TestContext.DataRow["result"].ToString());

            //Act
            bool result = firstLine.AreIntersected(secondLine);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\testData3.csv",
                    "testData3#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem("testData3.csv")]

        public void FindPointOfIntersectionTestMethodEquals()
        {
            //Arrange
            string data1 = TestContext.DataRow["line1"].ToString();
            string data2 = TestContext.DataRow["line2"].ToString();
            string[] coefficients1 = data1.Split(' ');
            string[] coefficients2 = data2.Split(' ');
            Line firstLine = new Line(double.Parse(coefficients1[0], InvariantCulture), double.Parse(coefficients1[1], InvariantCulture), 
                                        double.Parse(coefficients1[2], InvariantCulture));
            Line secondLine = new Line(double.Parse(coefficients2[0], InvariantCulture), double.Parse(coefficients2[1], InvariantCulture),
                                        double.Parse(coefficients2[2], InvariantCulture));
            double xCoordinate = Convert.ToDouble(TestContext.DataRow["x"].ToString());
            double yCoordinate = Convert.ToDouble(TestContext.DataRow["y"].ToString());
            Tuple<double, double> expectedResult = Tuple.Create(xCoordinate, yCoordinate);

            //Act
            Tuple<double, double> result = firstLine.FindPointOfIntersection(secondLine);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\testData4.csv",
                    "testData4#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem("testData4.csv")]

        public void IsPointOnLineTestMethodEquals()
        {
            //Arrange
            string data = TestContext.DataRow["line1"].ToString();
            string[] coefficients = data.Split(' ');
            Line line = new Line(double.Parse(coefficients[0], InvariantCulture), double.Parse(coefficients[1], InvariantCulture),
                                        double.Parse(coefficients[2], InvariantCulture));
            double xCoordinate = Convert.ToDouble(TestContext.DataRow["x"].ToString());
            double yCoordinate = Convert.ToDouble(TestContext.DataRow["y"].ToString());
            Tuple<double, double> point = Tuple.Create(xCoordinate, yCoordinate);
            bool expectedResult = bool.Parse(TestContext.DataRow["result"].ToString());

            //Act
            bool result = line.IsPointOnLine(point);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\testData5.csv",
                    "testData5#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem("testData5.csv")]

        public void AreParallelTestMethodEquals()
        {
            //Arrange
            string data1 = TestContext.DataRow["line1"].ToString();
            string data2 = TestContext.DataRow["line2"].ToString();
            string[] coefficients1 = data1.Split(' ');
            string[] coefficients2 = data2.Split(' ');
            Line firstLine = new Line(double.Parse(coefficients1[0], InvariantCulture), double.Parse(coefficients1[1], InvariantCulture),
                                        double.Parse(coefficients1[2], InvariantCulture));
            Line secondLine = new Line(double.Parse(coefficients2[0], InvariantCulture), double.Parse(coefficients2[1], InvariantCulture),
                                        double.Parse(coefficients2[2], InvariantCulture));
            bool expectedResult = bool.Parse(TestContext.DataRow["result"].ToString());

            //Act
            bool result = firstLine.AreParallel(secondLine);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\testData6.csv",
                    "testData6#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem("testData6.csv")]

        public void FindAngleBetweenLinesTestMethodEquals()
        {
            //Arrange
            string data1 = TestContext.DataRow["line1"].ToString();
            string data2 = TestContext.DataRow["line2"].ToString();
            string[] coefficients1 = data1.Split(' ');
            string[] coefficients2 = data2.Split(' ');
            Line firstLine = new Line(double.Parse(coefficients1[0], InvariantCulture), double.Parse(coefficients1[1], InvariantCulture),
                                        double.Parse(coefficients1[2], InvariantCulture));
            Line secondLine = new Line(double.Parse(coefficients2[0], InvariantCulture), double.Parse(coefficients2[1], InvariantCulture),
                                        double.Parse(coefficients2[2], InvariantCulture));
            double expectedResult = double.Parse(TestContext.DataRow["result"].ToString());

            //Act
            double result = firstLine.FindAngleBetweenLines(secondLine);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

    }

}
