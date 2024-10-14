

namespace BahaDev.EX.UoW
{
    public interface IServieces<T> where T : class
    {
        // إرجاع جميع الكيانات
        Task<List<T>> GetAll();

        // إرجاع كيان واحد بناءً على معرف (ID)
        Task<T?> GetById(Guid id);

        // إضافة كيان جديد
        Task<T> Insert(T entity);

        // تحديث كيان موجود
        Task<T> Update(T entity);

        // حذف كيان بناءً على معرف (ID)
        Task<bool> Delete(Guid id);
    }
}

