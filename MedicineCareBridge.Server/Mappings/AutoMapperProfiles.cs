using AutoMapper;
using MedicineCareBridge.DataAccess.Entities;
using MedicineCareBridge.Domain.Entities;
using MedicineCareBridge.Shared.DTO.Auth;
using MedicineCareBridge.Shared.DTO.Documents;
using MedicineCareBridge.Shared.DTO.Shared;
using MedicineCareBridge.Shared.DTO.User;

namespace MedicineCareBridge.Server.Mappings
{
    /// <summary>
    /// Профиль AutoMapper для всей системы.
    /// Здесь настраиваются все CreateMap для Entity, Domain и Shared.DTO.
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //
            // ===== User =====
            //
            // Entity → DTO
            CreateMap<UserEntity, UserReadDto>()
                .ForMember(dst => dst.Roles,
                           opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.NameEng)));

            // DTO → Entity (для создания пользователя)
            CreateMap<UserCreateDto, UserEntity>()
                .ForMember(dst => dst.Password,
                           opt => opt.Ignore()) // пароль хэшируем/назначаем в сервисе
                .ForMember(dst => dst.UserRoles,
                           opt => opt.Ignore()); // роли назначаем после создания

            // DTO → Domain
            CreateMap<RegisterRequestDto, User>()
                .ConstructUsing(dto => new User(dto.Login, dto.Password));

            //
            // ===== PersonalData =====
            //
            // Entity → DTO (используется в RegisterResponseDto или UserReadDto расширенном)
            CreateMap<PersonalDataEntity, PersonalDataDto>()
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));

            // DTO → Domain.Entity
            CreateMap<RegisterRequestDto, PersonalData>()
                .ConstructUsing(dto => new PersonalData(
                    0, // userId будет заменено в сервисе на реальный
                    dto.FirstName,
                    dto.LastName,
                    dto.MiddleName,
                    dto.DateOfBirth,
                    dto.Phone,
                    dto.Email
                ));

            //
            // ===== Passport =====
            //
            CreateMap<PassportEntity, PassportDto>().ReverseMap();

            CreateMap<PassportDto, Passport>()
                .ConstructUsing(dto => new Passport(
                    dto.DocumentName,
                    dto.PassportNum,
                    0, // userId будет заменено в сервисе на реальный
                    dto.Info,
                    dto.DateOfIssue,
                    0  // documentTypeId будет заменено в сервисе на реальный
                ));

            //
            // ===== Snils =====
            //
            CreateMap<SnilsEntity, SnilsDto>()
                .ForMember(dst => dst.NumSnils, opt => opt.MapFrom(src => src.NumSnils))
                .ReverseMap();

            CreateMap<SnilsDto, Snils>()
                .ConstructUsing(dto => new Snils(
                    dto.DocumentName,
                    dto.NumSnils,
                    0, // userId будет заменено в сервисе на реальный
                    0  // documentTypeId будет заменено в сервисе на реальный
                ));

            //
            // ===== InsuranceDocument =====
            //
            CreateMap<InsuranceDocumentEntity, InsuranceDocumentDto>().ReverseMap();

            CreateMap<InsuranceDocumentDto, InsuranceDocument>()
                .ConstructUsing(dto => new InsuranceDocument(
                    dto.DocumentName,
                    dto.Num,
                    0, // userId будет заменено в сервисе на реальный
                    0  // documentTypeId будет заменено в сервисе на реальный
                ));

            //
            // ===== UniversalDocument =====
            //
            CreateMap<UniversalDocumentEntity, UniversalDocumentDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Num, opt => opt.MapFrom(src => src.Num))
                .ForMember(dst => dst.DocumentName, opt => opt.MapFrom(src => src.DocumentName))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.DateOfIssue, opt => opt.MapFrom(src => src.DateOfIssue))
                .ReverseMap();

            CreateMap<UniversalDocumentDto, UniversalDocument>()
                .ConstructUsing(dto => new UniversalDocument(
                    dto.DocumentName,
                    dto.Num,
                    dto.Description ?? string.Empty,
                    dto.DateOfIssue,
                    0, // userId будет заменено в сервисе на реальный
                    0  // documentTypeId будет заменено в сервисе на реальный
                ));

            //
            // ===== Shared.Admin.UserDto =====
            //
            CreateMap<UserEntity, MedicineCareBridge.Shared.DTO.Admin.UserDto>()
                .ForMember(dst => dst.FullName,
                    opt => opt.MapFrom(src =>
                        src.PersonalData != null
                            ? src.PersonalData.LastName + " " + src.PersonalData.FirstName
                            : string.Empty))
                .ForMember(dst => dst.Role, opt =>
                {
                    // Берём первый nameEng из списка ролей или null
                    opt.MapFrom(src => src.UserRoles
                    .Select(ur => ur.Role.NameEng)
                    .FirstOrDefault());
                    // Если вышло null — заменяем на ""
                    opt.NullSubstitute(string.Empty);
                })
                .ForMember(dst => dst.LastLogin, opt => opt.Ignore());

            //
            // ===== PaginatedResult =====
            //
            // Специальных настроек не требует: создаётся вручную в сервисах
        }
    }
}