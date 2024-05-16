
namespace Graph;

public class graph{
    private List<dynamic> Set = new List<dynamic>();
    private Dictionary<int , dynamic> elements = new Dictionary<int , dynamic>();
    private List<List<bool>> Matrix = new List<List<bool>>();
    private bool Reflexive, Symmetric, AntiSymmetric, Transitive = true;
    public graph()
    {
        Reflexive = Symmetric = AntiSymmetric = Transitive = true;
    }
    public graph(List<dynamic> set)
    {
        Set = set;

        for(int i = 0; i < Set.Count; i++)
        {
            Matrix.Add(new List<bool>());
        }
        setRelations();

        Reflexive = Symmetric = AntiSymmetric = Transitive = true;
    }

    private void setRelations()
    {
        for (int i = 0; i < Set.Count; i++)
        {
            for (int j = 0; j < Set.Count; j++)
            {
                if(Set[i] <= Set[j])
                {
                    Matrix[i].Add(true);
                }
                else
                {
                    Matrix[i].Add(false);
                }
            }
        }
    }

    public void PrintRelations()
    {
        Console.WriteLine("\nR = {");
        for (int i = 0; i < Set.Count; i++)
        {
            for (int j = 0; j < Set.Count; j++)
            {
                if(Matrix[i][j] == true)
                {
                    Console.Write($"({Set[i]} , {Set[j]})\t");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("}\n");
    }

    private void CheckRelationPropertiesStates()
    {
        for (int i = 0; i < Set.Count; i++)
        {
            for (int j = 0; j < Set.Count; j++)
            {
                if (i == j && Matrix[i][j] == false)                    // check reflexive
                {
                    Reflexive = false;
                }

               if (Matrix[i][j] == true && i != j)
               {
                    if (Matrix[j][i] == false)                          // check symmetric
                    {
                        Symmetric = false;
                    }
                    else if(i != j)                                     // check anti-symmetric
                    {
                        AntiSymmetric = false;
                    }
                    if(Matrix[j][i] == true && Transitive == true)       // check transitive
                    {
                        for (int k = 0; k < Set.Count; k++)
                        {
                            if (Matrix[j][k] == true && j != k && i != k)
                            {
                                if (Matrix[i][k] == true)
                                {
                                    break;
                                }
                                else
                                {
                                    Transitive = false;
                                    break;
                                }
                            }
                            else if (j != k)
                            {
                                Transitive = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    public void PrintkRelationPropertiesStates()
    {
        CheckRelationPropertiesStates();

        Console.WriteLine($"Reflexive:\t {Reflexive}");
        Console.WriteLine($"Symmetric:\t {Symmetric}");
        Console.WriteLine($"AntiSymmetric:\t {AntiSymmetric}");
        Console.WriteLine($"Transitive:\t {Transitive}\n");
    }

    

}