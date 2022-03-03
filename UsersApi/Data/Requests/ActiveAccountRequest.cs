
using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Requests
{
    
//what app must receive to active user account

    public class ActiveAccountRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ActivationCode { get; set; }
    }

}
