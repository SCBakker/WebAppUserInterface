using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppUserInterfaceCultuurplein1db.data.WebAppUserInterfaceCultuurplein1;

namespace WebAppUserInterfaceCultuurplein1.Data
{
    public class UserInterfaceService
    {
        private readonly Cultuurplein1Context _context;

        public UserInterfaceService(Cultuurplein1Context context)
        {
            _context = context;
        }

        // Maakt een lijst van alle voorstellingen die in de database staan
        // en geeft deze terug aan de frontend

        public Task<List<Shows>>
            GetShowAsync(string strCurrentShow)
        {
            List<Shows> colAdminPage =
                new List<Shows>();
            colAdminPage =
                (from adminPage in _context.Shows
                 select adminPage).ToList();
            return Task.FromResult(colAdminPage);
        }

        // Geeft de afbeelding uit de database weer
        public List<Shows> DisplayImages()
        {
            return _context.Shows.ToList();
        }

    }
}
