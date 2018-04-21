using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortnerDotnetCore.Models;
using Z.EntityFramework.Plus;

namespace URLShortnerDotnetCore.Repository
{
    public class Urlservices
    {
        public const string BaseUrl = "http://localhost:5133/";
        public string GenerateShortUrlLog(string longUrl)
        {
            string shortUrl = string.Empty;
            using (URLShortnerContext db = new URLShortnerContext())
            {
                ShortUrllog _UrlLogDetails = new ShortUrllog();
                _UrlLogDetails.LongUrl = longUrl;
                _UrlLogDetails.UpdatedDate = DateTime.Now;
                db.ShortUrllog.Add(_UrlLogDetails);
                db.SaveChanges();
                var code = Base62EncodeDecode.Encode(_UrlLogDetails.Id);
                shortUrl = BaseUrl.ToString() + code;

                db.ShortUrllog.Where(f => f.Id == _UrlLogDetails.Id).Update(u => new ShortUrllog { Code = code });
            }
            return shortUrl;
        }

        public ShortUrllog Getcodebyurl(string code)
        {
            using (URLShortnerContext db = new URLShortnerContext())
            {
                long id = Base62EncodeDecode.Decode(code);
                var info = db.ShortUrllog.FirstOrDefault(f => f.Id == id);
                return info;
            }
        }
    }
}
