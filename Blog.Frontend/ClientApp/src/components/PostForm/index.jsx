import React, {useState} from 'react';
import { Button, Form, FormGroup, Label, Input, Row } from 'reactstrap';
import { Editor } from '@tinymce/tinymce-react';

export const PostForm = (props) => {

    const [form, setState] = useState(props.post);

    const handleEditorChange = (content, editor) => {
        setState({
            ...form,
            ["content"]: content
        });
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

            <Button color="primary">Submit</Button>
        </Form>
    );
}