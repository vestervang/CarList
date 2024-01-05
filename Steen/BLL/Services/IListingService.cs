using Domain.Models;

namespace BLL.Services
{
    public interface IListingService
    {
        Listing CreateListing(string name);
        List<Listing> GetListings();
    }
}