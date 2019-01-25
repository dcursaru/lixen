using System;
using System.Collections.Generic;

namespace Lixen.Core
{
    public class Simulator
    {

    }

    public class Id
    {
        
    }

    public interface IActualRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
    }
    
    public interface IReadableRepository<T>
    {
        T Get(Id id);
        IEnumerable<T> Get(AbstractSpecification<T> specification);
    }

    public interface IWritableRepository<in T>
    {
        void Save(T entity);
    }

    public class DapperRepository<T> : IReadableRepository<T>, IWritableRepository<T>
    {
        public T Get(Id id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Get(AbstractSpecification<T> specification)
        {
            throw new System.NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new System.NotImplementedException();
        }

        
    }
    public class DataContext
    {
        
    }

    
    public interface IGenericRepo<T>
    {
        T Get(string id);

    }
    
    public class GenericRepo<T> : IGenericRepo<T> where T: class 
    {
        private readonly DataContext _context;
        
        public GenericRepo(DataContext context)
        {
            _context = context;
        }

        public T Get(string id)
        {
            return default;
        }
    }
    
    public class PersonRepo : IGenericRepo<Scenario>
    {
        public PersonRepo()
        {
            
        }
        
        public Scenario Get(string id)
        {
            return new Scenario("1","Scenario 1");
        }
    }

    public class Client
    {
        public Client()
        {
            var repo = new GenericRepo<Scenario>(new DataContext());
            var scenario = repo.Get("1234");
        }
    }

    public class Scenario
    {
        public Scenario(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
        
        
    }
    
    public abstract class AbstractEntity<T> : IEquatable<T>
    {
        public abstract bool Equals(T other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AbstractEntity<T>) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AbstractEntity<T> left, AbstractEntity<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractEntity<T> left, AbstractEntity<T> right)
        {
            return !Equals(left, right);
        }
    }

    
    public class Person : AbstractEntity<Person>
    {
        public int Id { get; private set; }
        
        public override bool Equals(Person other)
        {
            return Id == other.Id;
        }
    }
}