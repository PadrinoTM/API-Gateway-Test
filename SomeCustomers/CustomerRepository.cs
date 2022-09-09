using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SomeCustomers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new List<Customer>();
        public CustomerRepository()
        {
            customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "Joydip",
                LastName = "Kanjilal",
                EmailAddress = "joydipkanjilal@yahoo.com"
            });

            customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "Steve",
                LastName = "Smith",
                EmailAddress = "stevesmith@yahoo.com"
            });

        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            var url = "https://localhost:44386/api/mail/SendEmail";
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            using (var httpClient = new HttpClient())
            {
                var mail = new MailRequest() { Subject = "Wallet Status", Body = "hey wallet created", Attachments = null, RecepientEmail = "tmidowu@gmail" };
                var mailSerialized = JsonSerializer.Serialize(mail);
                var mailContent = new StringContent(mailSerialized, Encoding.UTF8, "application/json");


                var postTask = await httpClient.PostAsync(url, mailContent);
                var mails = JsonSerializer.Deserialize<List<MailRequest>>(await httpClient.GetStringAsync(url), jsonSerializerOptions);
            }

            return await Task.FromResult(customers);
        }
    }
}
