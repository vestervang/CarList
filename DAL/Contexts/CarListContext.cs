using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts.Interfaces;

namespace DAL.Contexts
{
    public class CarListContext
    {
        private ICarContext? _carContext;

        public ICarContext CarContext
        {
            get
            {
                if (_carContext == null)
                {
                    _carContext = new CarContext(this);
                }

                return _carContext;
            }
        }

        private IListingContext _listingContext;

        public IListingContext ListingContext
        {
            get
            {
                if (_listingContext == null)
                {
                    _listingContext = new ListingContext(this);
                }

                return _listingContext;
            }
        }
    }
}
