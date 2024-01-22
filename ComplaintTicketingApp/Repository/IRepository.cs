using System.Linq.Expressions;

namespace ComplaintTicketingApp.Repository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll(Expression<Func<T, object>>[] includes);
		IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] includes
			, Expression<Func<T, object>> orderby);
		T GetById(int id);
		void AddEntity(T entity);
		void UpdateEntity(T entity);
		void RemoveEntity(int id);
		bool SaveChange();
	}
}
