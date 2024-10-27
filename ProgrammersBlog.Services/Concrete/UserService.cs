using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System.Linq;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    // Kullanıcıyı ID ile getirme
    public async Task<IDataResult<UserDto>> Get(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user != null)
        {
            return new DataResult<UserDto>(ResultStatus.Success, new UserDto { User = user });
        }
        return new DataResult<UserDto>(ResultStatus.Error, "Kullanıcı bulunamadı.", null);
    }

    // Tüm kullanıcıları listeleme
    public async Task<IDataResult<UserListDto>> GetAll()
    {
        var users = _userManager.Users.ToList();
        if (users.Count > 0)
        {
            return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto { Users = users });
        }
        return new DataResult<UserListDto>(ResultStatus.Error, "Hiçbir kullanıcı bulunamadı.", null);
    }

    // Kullanıcıyı kalıcı olarak silme (HardDeleteAsync)
    public async Task<IResult> HardDelete(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);  // Kullanıcıyı veritabanından sil
            if (result.Succeeded)
            {
                return new Result(ResultStatus.Success, $"{user.UserName} adlı kullanıcı başarıyla silindi.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Kullanıcı silinirken bir hata oluştu.");
            }
        }
        return new Result(ResultStatus.Error, "Kullanıcı bulunamadı.");
    }
}

