using UnityEngine;

namespace Skills
{
    public class Skill
    {
        private new string name;
        private string description;
        private int id;
        private float result;

        public Skill(string name, string description, int id, float result)
        {
            this.name = name;
            this.description = description;
            this.id = id;
            this.result = result;
        }

        //	Getter
        public string getName()
        {
            return name;
        }

        public string getDesc()
        {
            return description;
        }

        public int getId()
        {
            return id;
        }

        public float getResult()
        {
            return result;
        }
        //	Setter
        public void setName(string name)
        {
            this.name = name;
        }

        public void setDesc(string description)
        {
            this.description = description;
        }

        public void setResult(float result)
        {
            this.result = result;
        }

    }
}

