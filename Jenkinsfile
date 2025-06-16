pipeline {
    agent any

    environment {
        DOTNET = '/opt/homebrew/bin/dotnet'
       	DOCKER_IMAGE = "pashi44/onpmysql:latest"
        //DOCKER_CREDENTIALS_ID = 'dockerhub-creds' // Jenkins credentials ID
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'dev', url: 'https://github.com/pashi44/onpmysql.git'
            }
        }

        stage('Restore') {
            steps {
                sh '${DOTNET} restore'
            }
        }

        stage('Build') {
            steps {
                sh '${DOTNET} build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh '${DOTNET} publish -c Release -o ./publish'
            }
        }

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t ${DOCKER_IMAGE} .'
            }
        }

        //stage('Push Docker Image') {
          //  steps {
          //      withCredentials([usernamePassword(
            //        credentialsId: "${DOCKER_CREDENTIALS_ID}",
              //      usernameVariable: 'DOCKER_USER',
                //    passwordVariable: 'DOCKER_PASS'
               // )]) {
            //        sh '''
                  //      echo "$DOCKER_PASS" | docker login -u "$DOCKER_USER" --password-stdin
              //          docker push ${DOCKER_IMAGE}
                //    '''
                //}
            //}
       // }

        //stage('Deploy to Pi') {
          //  steps {
            //    sshagent (credentials: ['pi-ssh-creds']) {
              //      sh '''
                //        ssh -o StrictHostKeyChecking=no pi@<PI_IP> <<EOF
                  //      docker stop onpmysql || true
                    //    docker rm onpmysql || true
                      //  docker pull ${DOCKER_IMAGE}
                        //docker run -d --name onpmysql -p 80:80 ${DOCKER_IMAGE}
                        //EOF
                    //'''
               // }
            //}
        //}
        
    }

    post {
        failure {
            echo '❌ Build or deployment failed.'
        }
        success {
            echo '✅ Build (and publish) completed successfully!'
        }
    }
}
