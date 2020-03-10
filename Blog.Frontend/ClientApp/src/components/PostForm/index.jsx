import React, { useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Row } from 'reactstrap';
import { Editor } from '@tinymce/tinymce-react';
import { Typeahead } from 'react-bootstrap-typeahead';

export const PostForm = (props) => {

    const [form, setState] = useState(props.post);

    const handleEditorChange = (content, editor) => {
        setState({
            ...form,
            ["content"]: content
        });
    }

    const handleTagListChange = (items) => {
        setState({
            ...form,
            ["tags"] : items.map(e => {
                if(e && e.label)
                    return e.label;
                return e;
            })
        });
        // if(item && item)
        // console.log(item?.label);
    }

    const handleFormUpdates = (event) => {
        setState({
            ...form,
            [event.target.name]: event.target.value
        });
    }
    return (
        <Form onSubmit={event => props.onSubmit(event, form)}>
            <FormGroup>
                <Label for="exampleEmail">Title</Label>
                <Input type="text" value={form.title} name="title" onChange={handleFormUpdates} />
            </FormGroup>

            <Editor
                initialValue={props.post.content}
                init={{
                    height: 500,
                    menubar: false,
                    plugins: [
                        'advlist autolink lists link image charmap print preview anchor',
                        'searchreplace visualblocks code fullscreen',
                        'insertdatetime media table paste code help wordcount'
                    ],
                    toolbar:
                        'undo redo | formatselect | bold italic backcolor | \
                        alignleft aligncenter alignright alignjustify | \
                        bullist numlist outdent indent | removeformat | help'
                }}
                onEditorChange={handleEditorChange}
            />
            <FormGroup>
            <Label>Tags</Label>
                <Typeahead
                    onChange={handleTagListChange}
                    selected={form.tags}
                    allowNew
                    id="custom-selections-example"
                    multiple
                    newSelectionPrefix="Add a new item: "
                    options={[]}
                    placeholder="Type anything..."
                />
            </FormGroup>

            <Button color="primary">Submit</Button>
        </Form>
    );
}