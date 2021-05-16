using IndianStatesCeniusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCeniusAnalyser
{
    class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    //case (censusAnalyser.counry.US);
                    //return new UScensusAdapter().LoadCensusData(csvFilepath , dataHeaders)
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }

}

