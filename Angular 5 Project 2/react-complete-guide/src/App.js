import React, { Component } from 'react';
import './App.css';
import Person from './Person/Person'

class App extends Component {
  state = {
    persons: [
      { id: 3, name: 'Jotaro', stand: 'Star Platinum'},
      { id: 0},
      { id: 4, name: 'Josuke', stand: 'Crazy Diamond'},
      { id: 5, name: 'Giorno', stand: 'Gold Experience'}
    ],
    showPersons: false
  }

  changeNameHandler = (event, id) => {
    const personIndex = this.state.persons.findIndex(p => {
      return p.id === id;
    });

    const person = {...this.state.persons[personIndex]};

    person.name = event.target.value;

    const persons = [...this.state.persons];

    persons[personIndex] = person;

    this.setState({persons: persons});
  }

  toggleNamesHandler = () => {
    const doesShow = this.state.showPersons;
    this.setState({showPersons: !doesShow})
  }

  deletePersonHandler = (personIndex) => {
    //const persons = this.state.persons.slice();
    const persons = [...this.state.persons];
    persons.splice(personIndex, 1);
    this.setState({persons: persons});
  }

  render() {
    const style = {
      backgroundColor: '#3CB371',
      color: 'white',
      font: 'inherit',
      border: '2px solid #ff3377',
      padding: '10px',
      cursor: 'pointer'
    }

    let persons = null;

    if (this.state.showPersons) {
      persons = (
      <div>
        {this.state.persons.map((p, index) => {
          return <Person
            click={() => this.deletePersonHandler(index)}
            name={p.name}
            stand={p.stand}
            key={p.id}
            changedName={(event) => this.changeNameHandler(event, p.id)}/>
        })}
      </div>
      );

      style.backgroundColor = '#DC143C';
    }

    const classes = [];

    if (this.state.persons.length <= 2) {
      classes.push('red');
    }

    if (this.state.persons.length <= 1) {
      classes.push('bold');
    }

    return (
      <div className="App">
        <h1>This Is My React App!</h1>
        <p className={classes.join(' ')}>This app is really cool!</p>
        <button
          style={style}
          onClick={this.toggleNamesHandler}>ZA WURDO</button>
        {persons}
      </div>
    );
  }
}

export default App;
