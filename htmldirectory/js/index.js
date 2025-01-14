class Playground {
  constructor(id, name, maxChildren, minAge) {
    this.id = id;
    this.name = name;
    this.maxchildren = maxChildren;
    this.minage = minAge;
  }
}

const app = Vue.createApp({
  data() {
    return {
      tools: [{ name: "Vue.js", url: "https://vuejs.org/" },
      { name: "React.js", url: "https://reactjs.org/" },
      { name: "Angular", url: "https://angular.io/" },
      ],
      newName: "",
      newURL: "",
    }
  },
  methods: {
    async TryGet() {

    },
    async POST() {
      let newTool = {name: this.newName, url: this.newURL}; 
      this.tools.push(newTool); 
      console.log(newTool) 
    },

    async DELETE() {
      let idx = this.tools.findIndex((elem) => elem.name == this.newName); 
      this.tools.splice(idx, 1); 
      
    },
  },

  async mounted() {
    await this.TryGet();
  },

  computed: {

  },
})

app.mount('#app')

