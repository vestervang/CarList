using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utilities
{
    public sealed class CurrentListings
    {
        private static readonly Lazy<CurrentListings> lazy =
        new Lazy<CurrentListings>(() => new CurrentListings());

        public static CurrentListings Instance { get { return lazy.Value; } }

        private CurrentListings()
        {
        }

        public List<Listing> Listings{ get; set; } = new List<Listing>();
    }
}
