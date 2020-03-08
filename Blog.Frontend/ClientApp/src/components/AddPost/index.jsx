import React, { useState } from 'react';
import { PostData } from '../../infrastructure/request'
import { Loader } from '../Loader';
import { Redirect } from 'react-router';
import {PostForm} from '../PostForm';

export const AddPost = () => {
    const [showLoader, setShowLoader] = useState(false);
    const [redirectToPostList, setRedirectToPostList] = useState(false);

    const submit = (event, form) => {
        setShowLoader(true);
        event.preventDefault();
        PostData('https://localhost:44369/api/posts', form)
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
            <PostForm onSubmit={submit} post={{title: '', content: ''}}/>
        </>
    );
}


