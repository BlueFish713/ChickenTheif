using System;

public class PropertyAccessor<T>
{
    private readonly Func<T>   _getter;
    private readonly Action<T> _setter;

    public PropertyAccessor(Func<T> getter, Action<T> setter)
    {
        _getter = getter ?? throw new ArgumentNullException(nameof(getter));
        _setter = setter ?? throw new ArgumentNullException(nameof(setter));
    }

    public T Value
    {
        get => _getter();
        set => _setter(value);
    }

    public static PropertyAccessor<T> Create(Func<T> getter, Action<T> setter)
        => new PropertyAccessor<T>(getter, setter);
}