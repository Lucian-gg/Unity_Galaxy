public interface IFactory<T, P>
{

    T Create(P obj);

}

public interface IFactory<T>
{

    T Create();

}
