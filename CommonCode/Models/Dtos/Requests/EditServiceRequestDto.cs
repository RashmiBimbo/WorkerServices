﻿using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos.Requests
{
    public class EditServiceRequestDto
    {
        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string? Endpoint { get; set; }

        public bool? Enable { get; set; } = true;

        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string? Name { get; set; }

        public string? QueryString { get; set; }

        public TimeSpan? Period { get; set; }

        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string? Table { get; set; }

        public string? Columns { get; set; }

        public bool? TableAltered { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string? ModifiedBy { get; set; }
    }
}
