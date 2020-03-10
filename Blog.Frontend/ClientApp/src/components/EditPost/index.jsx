import React, { useState, useEffect } from 'react';
import { CreateApi } from '../../infrastructure/request'
import { Loader } from '../Loader';
import { Redirect } from 'react-router';
import { PostForm } from '../PostForm';

export const EditPost = (props) => {
    
    const [post, setPost] = useState();
    const [showLoader, setShowLoader] = useState(true);
    const api = CreateApi('https://localhost:44369/api');

    useEffect(() => {
        const postId = props.match.params.id;
        console.log(postId);
        api.getPost(postId)
            .then(data => setPost(data))
            .catch(reason => console.log(reason))
            .then(() => setShowLoader(false));
    }, [props.match.params.id])

    const submit = (event, form) => {
        
    }
    return (
        <>
            <h1>Edit Post</h1>
            {post && <PostForm onSubmit={submit} post={{title: post.title, content: post.content, tags: post.tags.map(t => t.tagName)}}/>}
            {showLoader && <Loader />}
        </>
    )
}