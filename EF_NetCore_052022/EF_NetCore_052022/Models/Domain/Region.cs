﻿using System.ComponentModel.DataAnnotations;

namespace EF_NetCore_052022.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
        //navigation  property
        public IEnumerable<Walk> Walks { get; set; }

    }
}
