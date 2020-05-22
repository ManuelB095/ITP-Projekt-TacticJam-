
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;   //vereinfacht das Suchen durch meinen Node Graph;
public class MouseManager : MonoBehaviour
{
    unit selectedUnit; //ausgewählte Unit
    Hex selectedHex; //ausgewähltes Hex Feld

    public GameObject meinHex;

    int line = 7;
    int collumn = 8;


    Node[,] graph; //Graphen in dem Die Knoten und deren Nachbarn gespeichert werden
    List<Node> currentPath = null;
    public class Node //Knoten enthält seine Position "posx/posy" und eine Knotenliste von Nachbarn
    {
        public List<Node> neighbours;
        public float posx;
        public float posz;
        public Node()
        {
            neighbours = new List<Node>();

        }

        //Berechnet die Distanz zwischen zwei Hex Feldern
        public float DistanceTo(Node n)
        {
            float z;
            float x;
            float distanz;
            if (posx > n.posx)
            {
                x = posx - n.posx;
            }
            else
            {
                x = n.posx - posx;
            }
            if (posz > n.posz)
            {
                z = posz - n.posz;
            }
            else
            {
                z = n.posz - posz;
            }

            distanz = Mathf.Sqrt(z);


            return distanz;

        }
    }





    // Start is called before the first frame update
    void Start()
    {
        generatePathGraph(line, collumn);  //erstellt Graphen zum Finden des Weges
        /* foreach (Node h in graph)
         {
             if (h != null)
             {
                 Debug.Log("Pos x: " + h.posx);
                 Debug.Log("Pos z: " + h.posz);
                 Debug.Log(h.neighbours);
             }

         }*/

    }

    // Update is called once per frame
    void Update()
    {
        //Ist die Maus über einem UI Element?

        //damit bekommen wir die Position der Maus auf unserem Feld
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        //Wenn wird mit der Mausposition ein Object treffen wird und das Object zurück gegeben
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

            //Über welchem Objekt befinden wir uns?
            if (ourHitObject.GetComponent<Hex>() != null)
            {
                MouseOver_Hex(ourHitObject);
            }

            else if (ourHitObject.GetComponent<unit>() != null)
            {
                MouseOver_unit(ourHitObject);
            }



        }
    }

    void MouseOver_Hex(GameObject ourHitObject)
    {

        //Haben wir eine Einheit ausgewählt?


        if (Input.GetMouseButtonDown(0))
        {

            //wenn wir eine Einheit ausgewählt haben, bewegen wir es auf das Hexfeld
            if (selectedUnit != null)  //Haben wir eine Einheit ausgewählt?
            {
                selectedHex = ourHitObject.GetComponent<Hex>();
                currentPath = null;
                //Debug.Log("Einheit x: " + graph[selectedUnit.spalte, selectedUnit.reihe].posx);
                //Debug.Log("Einheit y: " + graph[selectedUnit.spalte, selectedUnit.reihe].posz);

                //Debug.Log("Feld x: " + graph[selectedHex.x, selectedHex.z].posx);
                //Debug.Log("Feld y: " + graph[selectedHex.x, selectedHex.z].posz);
                path();

                //selectedUnit.destination = selectedHex.transform.position;

                //Die Position der Unit wird aktuallisiert
                selectedUnit.spalte = selectedHex.x;
                selectedUnit.reihe = selectedHex.z;


                MeshRenderer mr = selectedUnit.GetComponentInChildren<MeshRenderer>();
                {
                    mr.materials[0].color = Color.white;
                }
                selectedUnit = null;
                selectedHex = null;
            }

        }

    }

    void MouseOver_unit(GameObject ourHitObject)
    {

        //Haben wir eine Einheit ausgewählt?

        //Wenn man auf das Object klickt, wird die Farbe (MeshRenderer) verändert

        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit = ourHitObject.GetComponent<unit>();

            MeshRenderer mr = selectedUnit.GetComponentInChildren<MeshRenderer>();
            {
                mr.materials[0].color = Color.red;
            }
        }

    }



    //-------------------------Erstellt einen Tile Graphen für die Wegfindung----------------------------------------
    void generatePathGraph(int line, int collumn)
    {
        graph = new Node[line * 2 - 1, collumn];
        int check = collumn - 2;
        for (int x = 0; x < line * 2 - 1; x++)
        {

            for (int z = 0; z < collumn - check; z++)
            {
                graph[x, z] = new Node();

                if (GameObject.Find("Map/Hex" + x + "_" + z))
                {
                    //Debug.Log("Hex Gefunden");
                    graph[x, z].posx = GameObject.Find("Map/Hex" + x + "_" + z).transform.position.x;
                    graph[x, z].posz = GameObject.Find("Map/Hex" + x + "_" + z).transform.position.z;
                    //Debug.Log("Position x: " + GameObject.Find("Map/Hex" + x + "_" + z).transform.position.x);
                    //Debug.Log("Position y: " + GameObject.Find("Map/Hex" + x + "_" + z).transform.position.z);
                    //Debug.Log("Hex Nachbarn");
                }


            }
            if (x < line - 1)
            {
                check--;
            }

            else if (x >= line - 1)
            {
                check++;
            }
        }

        check = collumn - 2;
        for (int x = 0; x < line * 2 - 1; x++)
        {

            for (int z = 0; z < collumn - check; z++)
            {

                if (z > 0)
                {
                    graph[x, z].neighbours.Add(graph[x, z - 1]);  //darunter
                    //Debug.Log("Nachbar unten");
                }

                if (z < collumn - check - 1)
                {
                    graph[x, z].neighbours.Add(graph[x, z + 1]); //darüber
                    //Debug.Log("Nachbar oben");
                }

                if (x > 0 && z > 0 && x < line)
                {
                    graph[x, z].neighbours.Add(graph[x - 1, z - 1]); //links unten (linken Seite des Feldes)
                    //Debug.Log("Nachbar links unten");
                }
                else if (x > line - 1)
                {
                    graph[x, z].neighbours.Add(graph[x - 1, z]); //links unten (rechte Seite des Feldes)
                    //Debug.Log("Nachbar links unten");
                }

                if (x > 0 && z < (collumn - check - 1) && x < line)
                {
                    graph[x, z].neighbours.Add(graph[x - 1, z]); //links oben (linke Seite des Feldes)
                    //Debug.Log("Nachbar links oben");
                }
                else if (x > line - 1)
                {
                    graph[x, z].neighbours.Add(graph[x - 1, z + 1]);//links oben (rechte Seite des Feldes)
                    //Debug.Log("Nachbar links oben");
                }

                if (x < line - 1)
                {
                    graph[x, z].neighbours.Add(graph[x + 1, z + 1]);//rechts oben (linke Seite des Feldes)
                    //Debug.Log("Nachbar rechts oben");
                }
                else if (x < line * 2 - 2 && z < collumn - check - 1)
                {
                    graph[x, z].neighbours.Add(graph[x + 1, z]); //rechts oben (rechte Seite des Feldes)
                    //Debug.Log("Nachbar rechts oben");
                }

                if (x < line - 1)
                {
                    graph[x, z].neighbours.Add(graph[x + 1, z]);//rechts unten (linke Seite des Feldes)
                    //Debug.Log("Nachbar rechts unten");
                }
                else if (z > 0 && x < line * 2 - 2)
                {
                    graph[x, z].neighbours.Add(graph[x + 1, z - 1]); //rechts unten (rechte Seite des Feldes)
                    //Debug.Log("Nachbar rechts unten");
                }
            }
            if (x < line - 1)
            {
                check--;
            }

            else if (x >= line - 1)
            {
                check++;
            }
        }
    }

    void path()
    {
        //Der Pfad der Einheit wird geleert;
        selectedUnit.currentPath = null;

        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();
        //Notes die wir noch nicht überprüft haben;
        List<Node> unvisited = new List<Node>();



        Node source = graph[
                selectedUnit.spalte,
                selectedUnit.reihe
        ];

        Node target = graph[
                selectedHex.x,
                selectedHex.z
        ];

        dist[source] = 0;
        prev[source] = null;

        foreach (Node v in graph)
        {
            if (v != source && v != null)
            {
                dist[v] = Mathf.Infinity;
                prev[v] = null;
            }
            if (v != null)
            {
                //Debug.Log("Knoten x: " + v.posx);
                //Debug.Log("Knoten y: " + v.posz);
                unvisited.Add(v);
            }

        }

        while (unvisited.Count > 0)
        {
            //nicht schnell aber kurz;
            //"u" wird der nichtbesuchte Knoten sein, der am nächsten ist
            Node u = unvisited.OrderBy(n => dist[n]).First();




            if (u == target)
            {
                break;
            }


            unvisited.Remove(u);

            foreach (Node v in u.neighbours)
            {

                float alt = dist[u] + u.DistanceTo(v);
                //Debug.Log("alt " + alt);
                //Debug.Log("Distanz: " + u.DistanceTo(v));
                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }

        currentPath = new List<Node>();

        Node curr = target;
        //Geht durch die "prev" Kette und fügt sie zu unserem Pfad hinzu
        while (curr != null)
        {
            currentPath.Add(curr);
            curr = prev[curr];
        }

        //Der currentPath beschreibt einen Pfad von unserem Ziel zu unserem Start
        //Also müssen wir es umdrehen

        currentPath.Reverse();

        foreach (Node n in currentPath)
        {
            Debug.Log("Hefeld");
            Debug.Log("Position x: " + n.posx);
            Debug.Log("Position z: " + n.posz);
        }
        //Der Pfad der Einheit wird gefült
        selectedUnit.currentPath = currentPath;
    }


}
