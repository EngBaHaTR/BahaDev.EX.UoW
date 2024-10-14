using Microsoft.EntityFrameworkCore;

namespace BahaDev.EX.UoW
{
    public class RServieces <T , TContext> : IServieces<T> where T : class where TContext : DbContext
    {
        private readonly TContext _context;

        public RServieces(TContext context)
        {
            _context = context;
        }

        // إرجاع جميع الكيانات
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // إرجاع كيان واحد بناءً على معرف (ID)
        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // إضافة كيان جديد
        public async Task<T> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // تحديث كيان موجود
        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // حذف كيان بناءً على معرف (ID)
        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
