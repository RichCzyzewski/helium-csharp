﻿using CSE.Helium.Validation;
using System.ComponentModel.DataAnnotations;

namespace CSE.Helium
{
    public abstract class QueryParameters
    {
        private int pageNumber = 1;

        [IntegerRangeValidation(minValue: 0, maxValue: 9999)]
        public int PageNumber
        {
            get
            {
                // adjust for zero based Cosmos offset
                return pageNumber - 1;
            }
            set
            {
                pageNumber = value;
            }
        }

        [IntegerRangeValidation(minValue:1, maxValue:1000)]
        public int PageSize { get; set; } = 100;

        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "The parameter 'q' should be between {2} and {1} characters.")]
        public string Q { get; set; }
    }

    public sealed class MovieQueryParameters : QueryParameters
    {
        [IdValidation(startingCharacters:"nm", minimumCharacters:7, maximumCharacters:11, true)]
        public string ActorId { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "The parameter 'Genre' should be between {2} and {1} characters.")]
        public string Genre { get; set; }

        [YearValidation]
        public int Year { get; set; }
        
        [Range(minimum:0, maximum:10.0, ErrorMessage = "The parameter 'Rating' should be between {1} and {2}.")]
        public double Rating { get; set; }
    }

    public sealed class ActorQueryParameters : QueryParameters
    {
        // for future expansion
    }

    public sealed class MovieIdParameter
    {
        [IdValidation(startingCharacters:"tt", minimumCharacters:7, maximumCharacters:11, false)]
        public string MovieId { get; set; }
    }

    public sealed class ActorIdParameter
    {
        [IdValidation(startingCharacters:"nm", minimumCharacters:7, maximumCharacters:11, false)]
        public string ActorId { get; set; }
    }
}