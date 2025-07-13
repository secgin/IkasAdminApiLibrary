using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkasAdminApiLibrary.Abstracts
{
    internal interface IHttpClientService
    {
        Task<IResult<T>> GetAsync<T>(string uri);
    }
}
