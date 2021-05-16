﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCeniusAnalyser
{
    public class CensusAnalyserException : Exception
    {

        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY,
            HEADERS_MISMATCH,
            EXTENSION_NOT_FOUND
        }

        public ExceptionType eType;

        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }


    }
}
