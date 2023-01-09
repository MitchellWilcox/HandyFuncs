using System;
using System.Collections.Generic;

public class ObserverController
{
    private Dictionary<int, Subject> _subjectList;

    public ObserverController()
    {
        _subjectList = new Dictionary<int, Subject>();
    }

    public void AddSubject(int id)
    {
        _subjectList.Add(id, new Subject());
    }
    public void RegisterByID(int id, Action cb)
    {
        _subjectList[id].Register(cb);
    }

    public void UnRegisterByID(int id, Action cb)
    {
        _subjectList[id].UnRegister(cb);
    }

    public void NotifyByID(int id)
    {
        _subjectList[id].Notify();            
    }
}

public class Subject
{
    private Action _subscription;

    public Subject() { }

    public void Register(Action register)
    {
        _subscription += register;
    }

    public void UnRegister(Action register)
    {
        _subscription -= register;
    }

    public void Notify()
    {
        _subscription();
    }
}
