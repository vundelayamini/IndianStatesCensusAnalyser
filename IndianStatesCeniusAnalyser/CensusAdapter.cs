using IndianStatesCeniusAnalyser.DTO;
using IndianStatesCeniusAnalyser.DTO.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianStatesCeniusAnalyser
{
    public class CensusAdapter
    {
        public string[] GetCensusData(string csvFilepath, string dataHeaders)
        {
            string[] censusData;

            if (!File.Exists(csvFilepath))

                throw new CensusAnalyserException("File not found", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
            if (Path.GetExtension(csvFilepath) != ".csv")
                throw new CensusAnalyserException(" Invalid File type", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);

            if (censusData[0] == dataHeaders)
            {
                return censusData;

            }
            throw new CensusAnalyserException(" Incorrectt header in Data", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
        }

    }

}






