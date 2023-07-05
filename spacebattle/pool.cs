public class Pool<T> where T : new()
{
    private readonly object lockObject = new object();
    private readonly T[] pool;
    private int count;

    public Pool(int size)
    {
        pool = new T[size];
        count = size;

        for (int i = 0; i < size; i++)
        {
            pool[i] = new T();
        }
    }

    public T Acquire()
    {
        lock (lockObject)
        {
            if (count == 0)
            {
                throw new InvalidOperationException("All resources are currently in use.");
            }
            else
            {
                T obj = pool[count - 1];
                pool[count - 1] = default(T);
                count--;
                return obj;
            }
        }
    }

    public void Release(T obj)
    {
        lock (lockObject)
        {
            if (count == pool.Length)
            {
                throw new InvalidOperationException("Пул заполнен.");
            }

            pool[count] = obj;
            count++;
        }
    }
}

public class PoolGuard<T> : IDisposable  where T : new()
{
    Pool<T> pool;
    T item;

    public PoolGuard(Pool<T> pool)
    {
        this.pool = pool;
        item = pool.Acquire();
    }

    public T Item => item;

    public void Dispose()
    {
        if (item != null)
        {
            pool.Release(item);
            item = default(T);
        }
    }
}
