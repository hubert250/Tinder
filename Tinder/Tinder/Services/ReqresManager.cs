using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tinder.Models;

namespace Tinder.Services
{
    public class ReqresManager: IReqresManager
    {
        private const string APIURL = "https://reqres.in/api/users?page=";
        private HttpClient _client = new HttpClient();
        private int _currentPage = 0;

        public async Task<List<User>> GetUsers()
        {
            _currentPage++;

            var content = await _client.GetStringAsync(APIURL + _currentPage.ToString());
            List<User> users = new List<User>();

            try
            {
                var reqres = JsonConvert.DeserializeObject<Reqres>(content);
                users = reqres.data;
            }
            catch (Exception)
            {
            }

            return users;
        }


    }
}
