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

        public Task<Shows>
            CreateShowAsync(Shows objAdminPage)
        {
            _context.Shows.Add(objAdminPage);
            _context.SaveChanges();

            return Task.FromResult(objAdminPage);

        }

        public Task<bool>
            UpdateShowAsync(Shows objAdminPage)
        {
            var ExistingShow =
                _context.Shows
                    .Where(x => x.Id == objAdminPage.Id)
                    .FirstOrDefault();
            if (ExistingShow != null)
            {
                ExistingShow.Voorstelling =
                    objAdminPage.Voorstelling;
                ExistingShow.Beschrijving =
                    objAdminPage.Beschrijving;
                ExistingShow.Afbeelding =
                    objAdminPage.Afbeelding;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool>
            DeleteShowAsync(Shows objAdminPage)
        {
            var ExistingShows =
                _context.Shows
                    .Where(x => x.Id == objAdminPage.Id)
                    .FirstOrDefault();
            if (ExistingShows != null)
            {
                _context.Shows.Remove(ExistingShows);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
        public List<Shows> DisplayImages()
        {
            return _context.Shows.ToList();
        }

        public bool Uploadimg(Shows objAdminPage)
        {

            _context.Shows.Add(objAdminPage);
            _context.SaveChanges();

            return true;
        }

    }
}
