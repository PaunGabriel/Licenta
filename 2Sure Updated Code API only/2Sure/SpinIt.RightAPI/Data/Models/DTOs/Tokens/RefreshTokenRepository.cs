using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Models.DTOs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinIt.RightAPI.Data.Models.DTOs.Tokens
{
    public class RefreshTokenRepository : IRefreshToken
    {
        private readonly ApplicationDbContext _db;
        public RefreshTokenRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public int Count()
        {
            return _db.RefreshTokens.Count();
        }

        public void Delete(int id)
        {
            var refreshToken = GetByID(id);
            if (refreshToken != null)
            {
                _db.RefreshTokens.Remove(refreshToken);
            }
        }

        public IEnumerable<RefreshToken> GetAll()
        {
            return _db.RefreshTokens.Select(x => x);
        }

        public RefreshToken GetByID(int id)
        {
            return _db.RefreshTokens.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(RefreshToken catItem)
        {
            _db.RefreshTokens.Add(catItem);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(RefreshToken rft)
        {
            var _storedToken = _db.RefreshTokens.FirstOrDefault(m => m.Id == rft.Id);
            if (_storedToken != null)
            {
                _storedToken.Token = rft.Token;
                _storedToken.JwtID = rft.JwtID;
                  _storedToken.IsUsed = rft.IsUsed;
                  _storedToken.IsRevoked = rft.IsRevoked;
                _storedToken.AddedDate = rft.AddedDate;
                _storedToken.ExpiryDate = rft.ExpiryDate;
            }
    }
    }
}
