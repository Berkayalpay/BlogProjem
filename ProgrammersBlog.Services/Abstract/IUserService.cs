using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

public interface IUserService
{
    Task<IDataResult<UserDto>> Get(int userId);  // Kullanıcıyı getir
    Task<IDataResult<UserListDto>> GetAll();  // Tüm kullanıcıları getir
    Task<IResult> HardDelete(int userId);  // Kalıcı silme işlemi
}
