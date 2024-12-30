using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace disaster_management.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContextOptions<DaDManagementContext> _contextOptions;
      
        private readonly Dictionary<Type, string> _primaryKeyFields = new()
        {
            { typeof(DiseaseType), "DiseaseId" },
            { typeof(Outbreak), "OutbreakId" },
            { typeof(OutbreakDiagnosis), "DiagnosisId" },
            { typeof(Symptom), "SymptomId" },
            { typeof(Vaccination), "VaccinationId" },
            { typeof(Certificate), "CertificateId" },
            { typeof(LivestockFarm), "FarmId" },
            { typeof(LivestockFarmCondition), "ConditionId" },
            { typeof(Slaughterhouse), "SlaughterhouseId" },
            { typeof(SafeLivestockZone), "ZoneId" },
            { typeof(LivestockStatistic), "StatisticId" },
            { typeof(TemporaryZone), "ZoneId" },
            { typeof(VeterinaryBranch), "BranchId" },
            { typeof(VetMedicineAgency), "AgencyId" },
            { typeof(District), "DistrictId" },
            { typeof(Province), "ProvinceId" },
            { typeof(Ward), "WardId" },
            { typeof(User), "UserId" },
            { typeof(UserRole), "RoleId" },
            { typeof(UserGroup), "GroupId" },
             { typeof(UserLog), "LogId" },

        };
        public Repository(DbContextOptions<DaDManagementContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }
        private DaDManagementContext CreateContext()
        {
            return new DaDManagementContext(_contextOptions);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var context = CreateContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            using var context = CreateContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                using var context = CreateContext();
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "The entity to add cannot be null.");

                // Nếu thực thể đã được theo dõi, tách nó ra khỏi ChangeTracker
                var trackedEntity = context.ChangeTracker.Entries<T>()
                    .FirstOrDefault(e => e.Entity == entity);

                if (trackedEntity != null)
                {
                    trackedEntity.State = EntityState.Detached; // Tách thực thể đã được theo dõi
                }

                // Đặt giá trị của cột IDENTITY về null hoặc mặc định nếu tồn tại
                var primaryKeyProperty = context.Entry(entity).Properties
                    .FirstOrDefault(p => p.Metadata.IsPrimaryKey());

                if (primaryKeyProperty != null && primaryKeyProperty.Metadata.IsPrimaryKey())
                {
                    primaryKeyProperty.CurrentValue = null; // Đặt giá trị IDENTITY về null
                }

                // Thêm thực thể mới
                await context.Set<T>().AddAsync(entity);

                // Lưu thay đổi và xử lý ngoại lệ
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    throw new InvalidOperationException("An error occurred while saving the entity to the database. See inner exception for details.", ex);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm dữ liệu không thành công !");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                using var context = CreateContext();
                var entityType = typeof(T);

                // Lấy tên trường khóa chính
                if (!_primaryKeyFields.TryGetValue(entityType, out var primaryKeyField))
                {
                    throw new InvalidOperationException($"Primary key field not defined for type {entityType.Name}.");
                }

                // Lấy giá trị của khóa chính từ thực thể
                var primaryKeyValue = context.Entry(entity).Property(primaryKeyField).CurrentValue;

                // Tìm thực thể trong DbContext hoặc cơ sở dữ liệu
                var dbEntity = await context.Set<T>().FindAsync(primaryKeyValue);
                if (dbEntity != null)
                {
                    // Nếu thực thể tồn tại trong cơ sở dữ liệu, cập nhật giá trị
                    context.Entry(dbEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    // Nếu không tìm thấy trong cơ sở dữ liệu, gắn thực thể vào DbContext
                    context.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }

                // Loại trừ các trường không cần cập nhật
                if (_excludedFields.TryGetValue(entityType, out var excludedFields))
                {
                    foreach (var field in excludedFields)
                    {
                        var property = context.Entry(entity).Property(field);
                        if (property != null)
                        {
                            property.IsModified = false;
                        }
                    }
                }

                // Lưu thay đổi
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa dữ liệu không thành công !");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    context.Set<T>().Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if(ex.Source == "Microsoft.EntityFrameworkCore.Relational")
                {
                    MessageBox.Show("Không thể xoá dữ liệu có liên quan !");
                }
                else
                {
                    MessageBox.Show("Xoá dữ liệu không thành công !");

                }
            }

        }

        private readonly Dictionary<Type, string[]> _excludedFields = new()
        {
            { typeof(DiseaseType), new[] { "DiseaseId" } },
          //  { typeof(OtherEntity), new[] { "OtherId", "CreatedDate" } }
        };

    }
}
