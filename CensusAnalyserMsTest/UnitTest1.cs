using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using IndianStatesCeniusAnalyser;

namespace CensusAnalyserMsTest
{
    [TestClass]
    public class UnitTest1
    {

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DeliIndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongHeaderIndianCensusFile = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        static string IndianStateCodeFiletype = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static string delimeterIndianStateCodeFilePath = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\ DelimeterIndiaStateCode.csv";
        static string delimeterIndianCensusCodeFilePath = @"C:\Users\mahesh/Desktop\IndianCenusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimeterIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        private readonly object IndiaCensus;

        //setup the instances

        public void Setup()
        {
            censusAnalyser = new                                                                          
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }


        // TC1.1 Given the States Census CSV file, Check to ensure the Number of Record matches

        [TestMethod]
        public void GivenIndianCensusDataFile()
        {
            totalRecord = censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }


        // TC 1.2 Given the State Census CSV File if incorrect Returns a custom Exception

        [TestMethod]
        public void GivenWrongIndian()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, wrongIndianStateCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, indianCensusResult.eType);
        }


        // TC 1.3 Given the State Census CSV File when correct but type incorrect Returns a custom Exception

        [TestMethod]
        public void GivenWrongIndianCensusDataFileType()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, wrongIndianStateCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.EXTENSION_NOT_FOUND, indianCensusResult.type);
        }


        // TC 1.4 Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception

        [TestMethod]
        public void GivenWrongIndianCensusDataFileTypeDelimeter()
        {
            object IndiaCensus = null;
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, delimeterIndianCensusCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, indianCensusResult.eType);
        }


        // TC 1.5 Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception

        [TestMethod]
        public void GivenWrongIndianCensusDataHeadersCustomExcep()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndianStatesCeniusAnalyser.FileType.INDIAN_STATE_CENSUS, wrongHeaderIndianCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADERS_MISMATCH, indianCensusResult.eType);
        }

        public override bool Equals(object obj)
        {
            return obj is UnitTest1 test &&
                   EqualityComparer<CensusAnalyser>.Default.Equals(censusAnalyser, test.censusAnalyser);
        }
    }
}
