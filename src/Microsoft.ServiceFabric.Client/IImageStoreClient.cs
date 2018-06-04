// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;
    using Microsoft.ServiceFabric.Client.Exceptions;

    /// <summary>
    /// Interface containing methods for performing ImageStoreClient operataions.
    /// </summary>
    public interface IImageStoreClient
    {
        /// <summary>
        /// Gets the image store content information.
        /// </summary>
        /// <remarks>
        /// Returns the information about the image store content at the specified contentPath relative to the root of the
        /// image store.
        /// </remarks>
        /// <param name ="contentPath">Relative path to file or folder in the image store from its root.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ImageStoreContent> GetImageStoreContentAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes existing image store content.
        /// </summary>
        /// <remarks>
        /// Deletes existing image store content being found within the given image store relative path. This can be used to
        /// delete uploaded application packages once they are provisioned.
        /// </remarks>
        /// <param name ="contentPath">Relative path to file or folder in the image store from its root.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task DeleteImageStoreContentAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the content information at the root of the image store.
        /// </summary>
        /// <remarks>
        /// Returns the information about the image store content at the root of the image store.
        /// </remarks>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ImageStoreContent> GetImageStoreRootContentAsync(
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Copies image store content internally
        /// </summary>
        /// <remarks>
        /// Copies the image store content from the source image store relative path to the destination image store relative
        /// path.
        /// </remarks>
        /// <param name ="imageStoreCopyDescription">Describes the copy description for the image store.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task CopyImageStoreContentAsync(
            ImageStoreCopyDescription imageStoreCopyDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Cancels an image store upload session.
        /// </summary>
        /// <remarks>
        /// The DELETE request will cause the existing upload session to expire and remove any previously uploaded file chunks.
        /// </remarks>
        /// <param name ="sessionId">A GUID generated by the user for a file uploading. It identifies an image store upload
        /// session which keeps track of all file chunks until it is committed.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task DeleteImageStoreUploadSessionAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Commit an image store upload session.
        /// </summary>
        /// <remarks>
        /// When all file chunks have been uploaded, the upload session needs to be committed explicitly to complete the
        /// upload. Image store preserves the upload session until the expiration time, which is 30 minutes after the last
        /// chunk received.
        /// </remarks>
        /// <param name ="sessionId">A GUID generated by the user for a file uploading. It identifies an image store upload
        /// session which keeps track of all file chunks until it is committed.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task CommitImageStoreUploadSessionAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the image store upload session by ID.
        /// </summary>
        /// <remarks>
        /// Gets the image store upload session identified by the given ID. User can query the upload session at any time
        /// during uploading.
        /// </remarks>
        /// <param name ="sessionId">A GUID generated by the user for a file uploading. It identifies an image store upload
        /// session which keeps track of all file chunks until it is committed.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<UploadSession> GetImageStoreUploadSessionByIdAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the image store upload session by relative path.
        /// </summary>
        /// <remarks>
        /// Gets the image store upload session associated with the given image store relative path. User can query the upload
        /// session at any time during uploading.
        /// </remarks>
        /// <param name ="contentPath">Relative path to file or folder in the image store from its root.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<UploadSession> GetImageStoreUploadSessionByPathAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Uploads contents of the file to the image store.
        /// </summary>
        /// <remarks>
        /// Uploads contents of the file to the image store. Use this API if the file is small enough to upload again if the
        /// connection fails. The file's data will added to the request body. The contents will be uploaded to the
        /// specified path. Image store service uses a mark file to indicate the availability of the folder. The mark file is
        /// an empty file named "_.dir". The mark file is generated by the image store service when all files in a folder are
        /// uploaded. When using File-by-File approach to upload application package in REST, the image store service isn't
        /// aware of the file hierarchy of the application package; you need to create a mark file per folder and upload it
        /// last, to let the image store service know that the folder is complete.
        /// </remarks>
        /// <param name="fileContentsToUpload">Byte array containing file contents to upload.</param>
        /// <param name ="pathInImageStore">Relative path to file or folder in the image store from its root.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/> and Error Message <see cref="FabricError.Message"/> indicating the failure.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task UploadFileAsync(
            byte[] fileContentsToUpload,
            string pathInImageStore,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Uploads a file chunk to the image store relative path.
        /// </summary>
        /// <remarks>
        /// Uploads a file chunk to the image store with the specified upload session ID and image store relative path. This
        /// API allows user to resume the file upload operation. user doesn't have to restart the file upload from scratch
        /// whenever there is a network interruption. Use this option if the file size is large.
        /// 
        /// To perform a resumable file upload, user need to break the file into multiple chunks and upload these chunks to the
        /// image store one-by-one. Chunks don't have to be uploaded in order. If the file represented by the image store
        /// relative path already exists, it will be overwritten when the upload session commits.
        /// </remarks>
        /// <param name="fileChunkToUpload">Byte array containing file chunk to upload.</param>
        /// <param name ="pathInImageStore">Relative path to file or folder in the image store from its root.</param>
        /// <param name ="sessionId">A GUID generated by the user for a file uploading. It identifies an image store upload
        /// session which keeps track of all file chunks until it is committed.</param>
        /// <param name ="startBytePosition">The start position of the chunk in byte array represnting file contents.</param>
        /// <param name ="endBytePosition">The end position of the chunk in byte array representing file contents.</param>
        /// <param name="length">The size, in bytes, of the file for which chunk is to be uploaded.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <remarks>
        /// When uploading file chunks to the image store,  the Content Range information is sent to server.
        /// Example: if the total file length is 20,000 bytes, and chunk being uploaded is for first 5,000 bytes,
        /// value of <paramref name="startBytePosition"/> would be 0, value of <paramref name="endBytePosition"/> would be 4999 and value of
        /// <paramref name="length"/> would be 5000.
        /// </remarks>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/> and Error Message <see cref="FabricError.Message"/> indicating the failure.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task UploadFileChunkAsync(
            byte[] fileChunkToUpload,
            string pathInImageStore,
            Guid? sessionId,
            long startBytePosition,
            long endBytePosition,
            long length,
            long? serverTimeout = 60, CancellationToken cancellationToken = default(CancellationToken));


        /// <summary>
        /// Uploads application package to Service Fabric image store after compressing all sub-directories under the service directory.
        /// </summary>
        /// <param name="applicationPackagePath">Absolute path to application package.</param>        
        /// <param name="compressPackage">Compress the package before uploading.</param>        
        /// <param name="applicationPackagePathInImageStore">Relative path in the image store where the application package should be copied.
        /// If this is not specified, it defaults to the folder name as specified by applicationPackagePath.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/> and Error Message <see cref="FabricError.Message"/> indicating the failure.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task UploadApplicationPackageAsync(
            string applicationPackagePath,
            bool compressPackage = false,
            string applicationPackagePathInImageStore = default(string),
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
