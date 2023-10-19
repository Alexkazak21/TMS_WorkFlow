namespace Task2.Hospital;

internal abstract class Doctor
{
    private readonly string _name;
    private readonly string _specialization;

    public string Name { get => _name; }
    public string Specialization { get => _specialization; }

    public Doctor(string name, string specialization)
    {
        _name = name;
        _specialization = specialization;
    }
}
