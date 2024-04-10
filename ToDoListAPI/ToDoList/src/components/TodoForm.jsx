import React, { useState, useEffect, useRef } from 'react'
import Input from '@mui/joy/Input'
import Button from '@mui/joy/Button'



function TodoForm(props) {
  const [input, setInput] = useState(props.edit ? props.edit.value : '');

  const inputFocus = useRef(null)

  useEffect (() => {
    inputFocus.current.focus()
  })


  const handleChange = e =>{
    setInput(e.target.value)
  };

const handleSubmit = e => {
  e.preventDefault();

    props.onSubmit({
    id: Math.floor(Math.random() * 1000),
    text: input
  });
  setInput('');
};

return (
  <form onSubmit={handleSubmit} className='todo-form'>
    {props.edit ? (
      <>
      <div className='input-task-container'>
        <Input
          placeholder='Update your task'
          value={input}
          onChange={handleChange}
          name='text'
          ref={inputFocus}
          className='todo-input edit'
        />
        <Button variant="solid" onClick={handleSubmit} className='todo-button edit'>
          Update
        </Button>
        </div>
      </>
    ) : (
      <>
      <div className='input-task-container'>
        <Input
          placeholder='Add a task'
          value={input}
          onChange={handleChange}
          name='text'
          className='todo-input'
          ref={inputFocus}
        />
        <Button variant="solid" onClick={handleSubmit} className='todo-button'>
          Add task
        </Button>
        </div>
      </>
    )}
  </form>
);
}

export default TodoForm;
