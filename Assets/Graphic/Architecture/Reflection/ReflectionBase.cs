using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Reflection;
#nullable enable

public static class ReflectionBase //Reflection 관련 메소드 모은 Base 클래스
{
    private static ConcurrentDictionary<string, Type> _typeCache = new();

    /// <summary>
    /// value 이름의 클래스 Type을 반환하는 함수
    /// </summary> 
    public static Type? TypeFromString(string value)
    {
        //_typeCache 에 저장된 타입이면 바로 반환
        if (_typeCache.TryGetValue(value, out var cached))
            return cached;

        //현재 Assembly 찾기
        Assembly asm = Assembly.GetExecutingAssembly();

        // 2) 입력을 풀네임으로 간주해 검색
        var t = asm.GetType(value, throwOnError: false, ignoreCase: false);
        if (t != null)
        {
            // 풀네임 키 등록
            _typeCache[t.FullName!] = t;
            // 단순 이름 키도 등록
            _typeCache.TryAdd(t.Name, t);
            return t;
        }


        // 3) 입력을 단순 이름으로 간주해 검색 (네임스페이스 무시)
        t = null;
        foreach (var x in asm.GetTypes())
        {
            if (x.Name == value)
            {
                t = x;
                break;  // 첫 번째 매칭만 원하면 바로 탈출
            }
        }
        if (t != null)
        {
            _typeCache[t.FullName!] = t;
            _typeCache.TryAdd(t.Name, t);
            return t;
        }

        return null;
    }

    /// <summary>
    /// {prefix}+{enumValue}+{suffix} 이름의 클래스 Type을 반환하는 함수
    /// </summary> 
    public static Type? TypeFromEnum<TEnum>(TEnum enumValue, string prefix = "", string suffix = "") where TEnum : Enum
    {
        string className = $"{prefix}{enumValue}{suffix}";

        return TypeFromString(className);
    }

    public static string StringFromEnum<T>(T enumValue) where T : Enum
    {
        return enumValue.ToString();
    }

    /// <summary>
    /// Type 객체에서 단순 이름(string)을 얻습니다. (네임스페이스 제외)
    /// </summary>
    public static string? StringFromType(Type? type)
    {
        return type?.Name;
    }

    public static T? EnumFromString<T>(string value) where T : struct, Enum
    {
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;

        return null;
    }

    public static dynamic CreateInstanceFromType(Type type)
    {
        return Activator.CreateInstance(type);
    }
}