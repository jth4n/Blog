import * as React from 'react';
import { Container } from 'reactstrap';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
export const Post = () => {
    return (
        <Container>
            <h1>Create New Post</h1>
            <Form>
                <FormGroup>
                    <Label for="title">Title</Label>
                    <Input type="search" name="title" id="title" placeholder="Title" />
                </FormGroup>

                <FormGroup>
                    <Label for="exampleText">Text Area</Label>
                    <Input type="textarea" name="text" id="exampleText" />
                </FormGroup>
                <Button>Submit</Button>
            </Form>
        </Container>
    )
}