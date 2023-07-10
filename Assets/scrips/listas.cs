using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listas : MonoBehaviour
{
    public class pila<T>
    {
        public class node
        {
            T valor;
            int cantidadDeBalas;
            int cantidadDeBalasTotales;
            int cantidadDeBalasCargador;
            int daño;
            float tiempoMax;
            node next;
            node previus;

            public T Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previous
            {
                get { return previus; }
                set { previus = value; }
            }
            public int CantidadDeBalas
            {
                get { return cantidadDeBalas; }
                set { cantidadDeBalas = value; }
            }
            public int CantidadDeBalasTotales
            {
                get { return cantidadDeBalasTotales; }
                set { cantidadDeBalasTotales = value; }
            }
            public int CantidadDeBalasCargador
            {
                get { return cantidadDeBalasCargador; }
                set { cantidadDeBalasCargador = value; }
            }
            public float TiempoMax
            {
                get { return tiempoMax; }
                set { tiempoMax = value; }
            }
            public int Daño
            {
                get { return daño; }
                set { daño = value; }
            }
            public node(T v)
            {
                valor = v;
            }
            public node(T v, int cantidad, int cargador, float tiempo, int elDaño)
            {
                valor = v;
                cantidadDeBalas = cantidad;
                cantidadDeBalasCargador = cargador;
                tiempoMax = tiempo;
                daño = elDaño;
            }
            public node(T v, int cantidad, int cargador, int totales , float tiempo, int elDaño)
            {
                valor = v;
                cantidadDeBalas = cantidad;
                cantidadDeBalasCargador = cargador;
                cantidadDeBalasTotales = totales;
                tiempoMax = tiempo;
                daño = elDaño;
            }
        }

        node head;
        node tail;
        int cantidad;

        public node Head
        {
            get { return head; }
            set { head = value; }
        }



        public void Add(T dato, int cantidad, int cargador, float tiempo, int elDaño)
        {
            node newnode = new node(dato, cantidad, cargador, tiempo, elDaño);
            if(head == null)
            {
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node tmp = head;
                tmp.Previous = newnode;
                newnode.Next = tmp;
                head = newnode;
                cantidad = cantidad + 1;
            }
        }
        public void Add2(T dato, int cantidad, int cargador, int total, float tiempo, int elDaño)
        {
            node newnode = new node(dato, cantidad, cargador, total, tiempo, elDaño);
            if (head == null)
            {
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node tmp = head;
                tmp.Previous = newnode;
                newnode.Next = tmp;
                head = newnode;
                cantidad = cantidad + 1;
            }
        }


        public void remove()
        {
            node tmp = head;
            node newhead = head.Next;

            newhead.Previous = null;
            tmp.Next = null;
            head = newhead;
            cantidad = cantidad - 1;
        }

    }

    public class grafo<T>
    {
        public class node
        {
            T valor;
            node next;
            node previusly;
            listaDeDobleSentido<conexiones> lista = new listaDeDobleSentido<conexiones>();

            public T Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previusly
            {
                get { return previusly; }
                set { previusly = value; }
            }
            public node(T valou)
            {
                valor = valou;
                next = null;
                previusly = null;
            }
            public listaDeDobleSentido<conexiones> Lista
            {
                get { return lista; }
                set { lista = value; }
            }


        }
        public class conexiones
        {
            node elNodo;

            public node ElNode
            {
                get { return elNodo; }
                set { elNodo = value; }
            }

            public conexiones(node nodo)
            {
                elNodo = nodo;
            }
        }


        node head;
        node tail;
        int cantidad = 0;
        node tmp;
        node tmp2;
        public node Head
        {
            get { return head; }
            set { head = value; }
        }
        public node Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public node Tmp
        {
            get { return tmp; }
            set { tmp = value; }
        }
        public node Tmp2
        {
            get { return tmp2; }
            set { tmp2 = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public conexiones createConexion(node elnodo)
        {
            conexiones nodo = new conexiones(elnodo);
            return nodo;
        }
        public void add(T valor)
        {
            node newnode = new node(valor);
            if (head == null)
            {
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node tmp = tail;
                tail = newnode;
                tmp.Next = newnode;
                newnode.Previusly = tmp;
                cantidad = cantidad + 1;
            }

        }
        public node Position(int position)
        {
            int recorrido = 0;
            node tmp = head;
            while (recorrido < position - 1)
            {
                tmp = tmp.Next;
                recorrido = recorrido + 1;
            }
            return tmp;
        }


        #region asignarEspecial
        public void asignarEspecial(int posicion)
        {
            tmp = Position(posicion);
        }
        public void asignarEspecialConexion()
        {
            tmp = tmp.Lista.Head.Valou.ElNode;
        }
        public void asignarEspecial2(int posicion)
        {
            tmp2 = Position(posicion);
        }
        public void asignarEspecialConexion2()
        {
            tmp2 = tmp2.Lista.Head.Valou.ElNode;
        }
        #endregion
    }

    public class listaDeDobleSentido<T>
    {
        public class node
        {
            T valou;
            node next;
            node previusly;

            public T Valou
            {
                get { return valou; }
                set { valou = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previusly
            {
                get { return previusly; }
                set { previusly = value; }
            }

            public node(T valou)
            {
                Valou = valou;
                next = null;
                previusly = null;
            }
        }


        node head;
        node fin;
        int capacidad = 0;

        public node Head
        {
            get { return head; }
            set { head = value; }
        }

        #region add
        public void AddNodeStar(T valou)
        {
            node newnode = new node(valou);
            if (head == null)
            {
                head = newnode;
                fin = newnode;
                capacidad = capacidad + 1;
            }
            else
            {
                node tmp = head;
                head = newnode;
                newnode.Next = tmp;
                tmp.Previusly = newnode;
                capacidad = capacidad + 1;
            }
        }
        public void AddNodeEnd(T valou)
        {
            if (head == null)
            {
                AddNodeStar(valou);
            }
            else
            {
                node newnode = new node(valou);
                node tmp = fin;
                fin = newnode;
                tmp.Next = newnode;
                newnode.Previusly = tmp;
                capacidad = capacidad + 1;
            }
        }
        #endregion

        #region modify
        public void ModifyStart(T valou)
        {
            if (head == null)
            {
                Debug.Log("no se puede");
            }
            else
            {
                head.Valou = valou;
            }
        }
        public void ModifyEnd(T valou)
        {
            if (head == null)
            {
                Debug.Log("Esto no se puede hacer");
            }
            else
            {
                fin.Valou = valou;
            }
        }
        public void ModifyPosition(T valou, int position)
        {
            if (head == null)
            {
                Debug.Log("Esto no se puede hacer");
            }
            else
            {
                node tmp = Position(position);
                tmp.Valou = valou;
            }
        }
        #endregion

        #region remove
        public void RemoveStart()
        {
            if (head == null)
            {
                Debug.Log("Eso no se puede hacer ");
            }
            else
            {
                node newhead = head.Next;
                newhead.Previusly = null;
                head = newhead;
                capacidad = capacidad - 1;
            }
        }
        public void RemoveEnd()
        {
            if (head == null)
            {
                Debug.Log("Eso no se puede hacer ");
            }
            else
            {
                node newfin = fin.Previusly;
                newfin.Next = null;
                fin = newfin;
                capacidad = capacidad - 1;
            }
        }
        public void RemovePosition(int position)
        {
            if (head == null || position < 0 || position > capacidad)
            {
                Debug.Log("Eso no se puede hacer ");
            }
            else if (position == 0)
            {
                RemoveStart();
            }
            else if (position == capacidad)
            {
                RemoveEnd();
            }
            else
            {
                node tmp = Position(position);
                node next = tmp.Next;
                node previusly = tmp.Previusly;
                next.Previusly = previusly;
                previusly.Next = next;
            }
        }
        #endregion

        #region extra
        public node Position(int position)
        {
            int recorrido = 0;
            node tmp = head;
            while (recorrido < position - 1)
            {
                tmp = tmp.Next;
                recorrido = recorrido + 1;
            }
            return tmp;
        }
        #endregion

        #region getNodePosicion
        public T GetNodeStart()
        {
            if (head == null)
            {
                throw new("Eso no se puede hacer ");
            }
            else
            {
                T x;
                x = head.Valou;
                return x;
            }
        }
        public T GetNodeEnd()
        {
            if (head == null)
            {
                throw new("Eso no se puede hacer ");
            }
            else
            {
                T x;
                x = fin.Valou;
                return x;
            }
        }
        public T GetNodePositin(int position)
        {
            if (head == null || position < 0 || position > capacidad)
            {
                throw new("Eso no se puede hacer ");
            }
            else if (position == 0)
            {
                T x = GetNodeStart();
                return x;
            }
            else if (position == capacidad)
            {
                T x = GetNodeEnd();
                return x;
            }
            else
            {
                node tmp = Position(position);
                T x;
                x = tmp.Valou;
                return x;
            }
        }
        public T GetNodePreviuslyPosition(int position)
        {
            position = position - 1;
            T x = GetNodePositin(position);
            return x;
        }
        public T GetNodeNextPosition(int position)
        {
            position = position + 2;
            T x = GetNodePositin(position);
            return x;
        }
        #endregion

        #region allnodes
        public void AllNodeNormal()
        {
            node tmp = head;
            while (tmp != null)
            {
                Debug.Log(tmp.Valou);
                tmp = tmp.Next;
            }
        }
        public void AllNodereverse()
        {
            node tmp = fin;
            while (tmp != null)
            {
                Debug.Log(tmp.Valou);
                tmp = tmp.Previusly;
            }
        }
        public void AllNode()
        {
            Debug.Log("Todos los datos en orden:");
            Debug.Log("");
            AllNodeNormal();
            Debug.Log("");
            Debug.Log("");
            Debug.Log("Todos los datos en reversa:");
            Debug.Log("");
            AllNodereverse();
            Debug.Log("");
            Debug.Log("");
        }
        #endregion

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
