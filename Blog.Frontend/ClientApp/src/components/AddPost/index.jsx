import React, { useState } from 'react';
import { CreateApi } from '../../infrastructure/request'
import { Loader } from '../Loader';
import { Redirect } from 'react-router';
import { PostForm } from '../PostForm';

export const AddPost = () => {
    const [showLoader, setShowLoader] = useState(false);
    const [redirectToPostList, setRedirectToPostList] = useState(false);

    const api = CreateApi('https://localhost:44369/api');

    const submit = (event, form) => {
        setShowLoader(true);
        event.preventDefault();
        api.createPost(form)
            .then(response => {
                console.log(response);
            })
            .catch(reason => console.log(reason))
            .then(() => {
                setShowLoader(false);
                setRedirectToPostList(true);
            });
    }

    return (
        <>
            {redirectToPostList && <Redirect to="/posts" />}
            {showLoader && <Loader />}
            <PostForm onSubmit={submit} post={{ title: '', content: '', tags: ['Whisky', 'Scotch'] }} />
        </>
    );
}


