﻿using System.Collections.Generic;

namespace JSonHandler
{
    public class AntennaConfiguration
    {
        public List<Antenna> Antennas = new List<Antenna>();
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}